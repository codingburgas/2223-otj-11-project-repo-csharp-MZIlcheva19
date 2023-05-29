using System.Text;
using System.Security.Cryptography;
using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using bsm.util;
using Microsoft.IdentityModel.Tokens;

namespace bsm.bll
{
    public class UserService
    {
        public static List<User> GetEmployees()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                List<User> userList = userRepository.GetAll().Where(u => u.TypeId == (int)TypeCodes.Employee).ToList();

                return userList;
            }
        }

        public static User GetUserById(int userId)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                return userRepository.GetAll().FirstOrDefault(u => u.Id == userId);
            }
        }

        public static List<User> GetApprovalRequestingUsers()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                List<User> users = userRepository.GetAll().Where(u => u.EmployeeRequest == true).ToList();

                return users;
            }
        }

        public static User GetUserByUsername(string username)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User? user = userRepository.GetUserByUsername(username);

                return user;
            }
        }

        public static bool LoginUser(string username, string password)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                bool verifyUser = false;

                User? user = GetUserByUsername(username);

                if (user != null)
                {
                    string saltedPassword = password + user.Salt;
                    string hashedPass = HashPassword(saltedPassword);

                    if (user.Password == hashedPass)
                    {
                        verifyUser = true;
                    }
                }

                return verifyUser;
            }
        }

        public static void RegisterUser(string username, string password, string fName, string lName, string phone, string email)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User user = new();
                user.Username = username;

                user.Salt = GenerateSalt();
                string saltedPassword = password + user.Salt;
                user.Password = HashPassword(saltedPassword);

                user.FirstName = fName;
                user.LastName = lName;
                user.Phone = phone;
                user.Email = email;
                user.TypeId = (int)TypeCodes.Client;
                user.EmployeeRequest = false;

                if(user != null)
                {
                    userRepository.AddRow(user);
                }
            }
        }

        public static void EditUser(User user, string username, string password, string fName, string lName, string phone, string email)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                user.Username = username;
                string saltedPassword = password + user.Salt;
                user.Password = HashPassword(saltedPassword);
                user.FirstName = fName;
                user.LastName = lName;
                user.Phone = phone;
                user.Email = email;

                userRepository.UpdateRow(user);
            }
        }

        public static void DeleteUser(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                AppointmentService.DeleteUserAppointments(user);    
                UserSkillService.DeleteAllUsersSkills(user);

                userRepository.DeleteRow(user);
            }
        }

        public static void ChangeRequestApproval(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                if(user.EmployeeRequest != null)
                {
                    user.EmployeeRequest = !user.EmployeeRequest;
                }
                else
                {
                    user.EmployeeRequest = true;
                }

                userRepository.UpdateRow(user);
            }
        }
        
        public static void MakeEmployee(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                user.TypeId = (int)TypeCodes.Employee;
                user.EmployeeRequest = false;

                userRepository.UpdateRow(user);
            }
        }

        public static void MakeClient(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                UserSkillService.DeleteAllUsersSkills(user);
                user.TypeId = (int)TypeCodes.Client;
                user.EmployeeRequest = false;

                userRepository.UpdateRow(user);
            }
        }

        public static void AddAdmin()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User? user = GetUserByUsername("admin");

                if (user == null)
                {
                    string salt = GenerateSalt();
                    string saltedPassword = "admin" + salt;
                    string hashedPassword = HashPassword(saltedPassword);

                    User admin = new()
                    {
                        Username = "admin",
                        Password = hashedPassword,
                        Salt = salt,
                        FirstName = "admin",
                        LastName = "admin",
                        Phone = "0000000000",
                        Email = "admin@email.com",
                        TypeId = (int)TypeCodes.Admin
                    };

                    userRepository.AddRow(admin);
                }
            }
        }

        public static string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }

        public static int CheckUsername(string username)
        {
            if (username.IsNullOrEmpty())
            {
                return 1;
            }
            if (username.Length < 4 || username.Length > 12)
            {
                return 2;
            }
            if (GetUserByUsername(username) != null)
            {
                return 3;
            }
            return 0;
        }

        public static int CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return 1;
            }

            if (password.Length < 4 || password.Length > 12)
            {
                return 2;
            }

            if (password.Where(c => Char.IsWhiteSpace(c)).Any())
            {
                return 3;
            }

            if (!password.Any(c => Char.IsDigit(c)))
            {
                return 4;
            }

            string specialCharacters = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            if (password.Any(c => specialCharacters.Any(x => x == c)))
            {
                return 5;
            }

            return 0;
        }
        public static int CheckName(string name)
        {
            if (name.IsNullOrEmpty())
            {
                return 1;
            }
            if (name.Any(c => Char.IsDigit(c)))
            {
                return 2;
            }
            return 0;
        }

        public static int CheckPhone(string phone)
        {
            if (phone.IsNullOrEmpty())
            {
                return 1;
            }
            if (phone.Length < 10 || phone.Length > 15)
            {
                return 2;
            }
            if (phone.Any(c => Char.IsLetter(c)))
            {
                return 3;
            }
            return 0;
        }

        public static int CheckEmail(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return 1;
            }
            if (!email.Any(c => c == '@') || email.Count(c => c == '@') > 1)
            {
                return 2;
            }
            if (email.Substring(email.IndexOf('@')).Length < 4)
            {
                return 3;
            }
            return 0;
        }
    }
}
using System.Text;
using System.Security.Cryptography;
using bsm.dal.Repositories;
using bsm.dal.Models;
using bsm.dal.Data;
using bsm.util;

namespace bsm.bll
{
    public class UserService
    {
        // Retrieves all employees
        public static List<User> GetEmployees()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                List<User> userList = userRepository.GetAll().Where(u => u.TypeId == (int)TypeCodes.Employee).ToList();

                return userList;
            }
        }

        // Retrieves a user by their ID
        public static User GetUserById(int userId)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                return userRepository.GetAll().FirstOrDefault(u => u.Id == userId);
            }
        }

        // Retrieves users requesting approval
        public static List<User> GetApprovalRequestingUsers()
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                List<User> users = userRepository.GetAll().Where(u => u.EmployeeRequest == true).ToList();

                return users;
            }
        }

        // Retrieves a user by their username
        public static User? GetUserByUsername(string username)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                User? user = userRepository.GetUserByUsername(username);

                return user;
            }
        }

        // Validates user login credentials
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

        // Registers a new user
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

                if (user != null)
                {
                    userRepository.AddRow(user);
                }
            }
        }

        // Edits a user's details
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

        // Deletes a user
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

        // Toggles the approval status of a user
        public static void ChangeRequestApproval(User user)
        {
            using (var context = new BeautySalonContext())
            {
                UserRepository userRepository = new(context);

                if (user.EmployeeRequest != null)
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

        // Sets a user as an employee
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

        // Sets a user as a client
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

        // Adds an admin user
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

        // Generates a random salt
        public static string GenerateSalt()
        {
            Random rnd = new Random();

            byte[] rndBytes = new byte[16];
            rnd.NextBytes(rndBytes);

            string salt = Convert.ToHexString(rndBytes);

            return salt;
        }

        // Hashes a password using SHA256
        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            byte[] passBytes = Encoding.Default.GetBytes(password);

            string hashedPass = Convert.ToHexString(hash.ComputeHash(passBytes));

            return hashedPass;
        }
    }
}

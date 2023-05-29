using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class RegisterUserMenu
    {
        public static void Print()
        {
            Console.Clear();
            Write.LineToCenter("Register User");
            Console.WriteLine();

            string username = InsertUsername();
            string password = InsertPassword();
            string fName = InsertFirstName();
            string lName = InsertLastName();
            string phone = InsertPhone();
            string email = InsertEmail();

            UserService.RegisterUser(username, password, fName, lName, phone, email);

            UserLog.LoggedUser = UserService.GetUserByUsername(username);

            Console.WriteLine();
            Write.LineToCenter("User registered");
            Console.ReadKey();
            MainMenu.Print();
        }
        private static string InsertUsername()
        {
            Write.ToCenter("Username: ");
            string? username = Console.ReadLine();

            if (username.ToUpper() == "B")
            {
                MainMenu.Print();
            }

            switch (UserService.CheckUsername(username))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Username is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter($"Username must be from 4 to 12 characters");
                    Console.ReadKey();
                    Print();
                    break;
                case 3:
                    Console.WriteLine();
                    Write.LineToCenter("Username already in use");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return username;
        }

        private static string InsertPassword()
        {
            Write.ToCenter("Password: ");
            string? password = Console.ReadLine();

            switch (UserService.CheckPassword(password))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Password is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter("Password needs to be 4 to 12 characters");
                    Console.ReadKey();
                    Print();
                    break;
                case 3:
                    Console.WriteLine();
                    Write.LineToCenter("String has empty characters");
                    Console.ReadKey();
                    Print();
                    break;
                case 4:
                    Console.WriteLine();
                    Write.LineToCenter("Password must have a number");
                    Console.ReadKey();
                    Print();
                    break;
                case 5:
                    Console.WriteLine();
                    Write.LineToCenter("Password has special symbols");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return password;
        }

        private static string InsertFirstName()
        {
            Write.ToCenter("First Name: ");
            string? firstName = Console.ReadLine();

            switch (UserService.CheckName(firstName))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("First Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter("First Name must not have numbers");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return firstName;
        }

        private static string InsertLastName()
        {
            Write.ToCenter("Last Name: ");    
            string? lastName = Console.ReadLine();

            switch (UserService.CheckName(lastName))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Last Name is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter("Last Name must not have numbers");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return lastName;
        }

        private static string InsertPhone()
        {
            Write.ToCenter("Phone: ");
            string? phone = Console.ReadLine();

            switch (UserService.CheckPhone(phone))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Phone is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter("Phone must 10 to 15 characters");
                    Console.ReadKey();
                    Print();
                    break;
                case 3:
                    Console.WriteLine();
                    Write.LineToCenter("Phone must not have letters");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return phone;
        }

        private static string InsertEmail()
        {
            Write.ToCenter("Email: ");
            string? email = Console.ReadLine();

            switch (UserService.CheckEmail(email))
            {
                case 1:
                    Console.WriteLine();
                    Write.LineToCenter("Email is required");
                    Console.ReadKey();
                    Print();
                    break;
                case 2:
                    Console.WriteLine();
                    Write.LineToCenter("Email is invalid");
                    Console.ReadKey();
                    Print();
                    break;
                case 3:
                    Console.WriteLine();
                    Write.LineToCenter("Email has no domain");
                    Console.ReadKey();
                    Print();
                    break;
                default: break;
            }
            return email;
        }
    }
}

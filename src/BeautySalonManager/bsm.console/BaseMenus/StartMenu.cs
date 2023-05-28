using bsm.bll;

namespace bsm.console
{
    internal class StartMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.WriteLine($"{"Beauty Salon Management System",39}");
            Console.WriteLine();

            Console.WriteLine($"{"[R] Register",30}");  // Display option to register a new user
            Console.WriteLine($"{"[L] Login",27}");  // Display option to login
            Console.WriteLine($"{"[E] Exit",26}");  // Display option to exit the program

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);  // Read a key from the console and convert it to uppercase

                switch (input)
                {
                    case 'R': RegisterUserMenu.Print(); break;  // If the input is 'R', invoke the Print() method of RegisterUserMenu
                    case 'L': LoginUserMenu.Print(); break;  // If the input is 'L', invoke the Print() method of LoginUserMenu
                    case 'E': Environment.Exit(0); break;  // If the input is 'E', exit the program
                    default: break;  // If the input doesn't match any of the cases, do nothing and continue the loop
                }
            }
        }
    }
}

using bsm.bll;

namespace bsm.console
{
    internal class StartMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.WriteLine($"{"Beauty Salon Management System", 39}");
            Console.WriteLine();

            Console.WriteLine($"{"[R] Register", 30}");
            Console.WriteLine($"{"[L] Login", 27}");
            Console.WriteLine($"{"[E] Exit", 26}");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'R': RegisterUserMenu.Print(); break;
                    case 'L': LoginUserMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}

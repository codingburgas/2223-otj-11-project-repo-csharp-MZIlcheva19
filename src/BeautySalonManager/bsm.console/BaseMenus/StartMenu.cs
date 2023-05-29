using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class StartMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Write.LineToCenter("Beauty Salon Management System");
            Console.WriteLine();

            Write.LineToCenter("[R] Register");
            Write.LineToCenter("[L] Login   ");
            Write.LineToCenter("[E] Exit    ");

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

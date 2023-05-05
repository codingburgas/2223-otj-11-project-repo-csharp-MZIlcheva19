using bsm.bll;

namespace bsm.console
{
    internal class Start
    {
        static void Main(string[] args)
        {
            Print();
        }

        private static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.WriteLine("[R] Register  [L] Login");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'R': RegisterMenu.Print(); break;
                    case 'L': LoginMenu.Print(); break;
                    case 'B': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}
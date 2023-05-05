using bsm.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    internal class StartMenu
    {
        public static void Print()
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

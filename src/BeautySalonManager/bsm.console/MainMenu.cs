using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bsm.console.UserMenu;

namespace bsm.console
{
    public class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[R] Register  [L] Login");
            
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch(input)
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

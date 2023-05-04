using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console
{
    public class MainMenu
    {
        public static void Print()
        {
            Console.Clear();

            Console.WriteLine("[R] Register");
            
            while(true)
            {
                var input = Char.ToUpper(Console.ReadKey().KeyChar);

                switch(input)
                {
                    case 'R': RegisterMenu.Print(); break;
                    case 'B': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}

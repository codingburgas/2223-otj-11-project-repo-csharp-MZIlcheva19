using bsm.console.ServiceMenus;
using bsm.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.console.BaseMenus
{
    internal class AdminMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("[S] Services  [U] Users  [B] Back");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': ServiceEditMenu.Print(); break;
                    case 'U': Console.WriteLine("Call UsersEditMenu"); /* call UsersEditMenu */ break;
                    case 'B': MainMenu.Print(); break;
                    default: break;
                }
            }
        }
    }
}

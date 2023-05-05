using bsm.bll;
using bsm.util;
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
            UserService.AddAdmin();

            Console.Write("[S] Services  [O] Options  [L] LogOut  ");
            if(UserLog.LoggedUser.Username == "admin")
                Console.WriteLine("[A] Panel");
            else
                Console.WriteLine();

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': /* call ServicesMenu */ break;
                    case 'O': /* call OptionsMenu */ break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'A': if (UserLog.LoggedUser.Username == "admin") /* call AdminPanelMenu */ break; break;
                    case 'B': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}

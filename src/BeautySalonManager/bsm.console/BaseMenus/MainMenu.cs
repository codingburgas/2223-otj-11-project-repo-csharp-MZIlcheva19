using bsm.bll;
using bsm.util;

namespace bsm.console
{
    public class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.Write("[S] Services  [O] Options  [L] LogOut  [E] Exit  ");
            if (UserLog.LoggedUser.Username == "admin")
                Console.WriteLine("[A] Panel");
            else
                Console.WriteLine();

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': Console.WriteLine("Call ServicesMenu"); /* call ServicesMenu */ break;
                    case 'O': Console.WriteLine("Call OptionsMenu"); /* call OptionsMenu */ break;
                    case 'L': UserLog.LoggedUser = null; StartMenu.Print(); break;
                    case 'A': if (UserLog.LoggedUser.Username == "admin") Console.WriteLine("Call AdminPanelMenu"); /* call AdminPanelMenu */ break;
                    case 'E': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}

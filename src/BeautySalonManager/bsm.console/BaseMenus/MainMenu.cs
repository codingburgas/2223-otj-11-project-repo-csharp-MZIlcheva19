using bsm.bll;
using bsm.util;

namespace bsm.console
{
    internal class MainMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.Write("[S] Services  [O] Options  ");
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Employee)
            {
                Console.Write("[K] Skills  ");
            }
            if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin)
            {
                Console.Write("[A] Panel  ");
            }
            Console.WriteLine("[E] Exit");

            while (true)
            {
                var input = char.ToUpper(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'S': Console.WriteLine("Call ServicesMenu"); /* call ServicesMenu */ break;
                    case 'O': Console.WriteLine("Call OptionsMenu"); OptionsMenu.Print(); break;
                    case 'A': if (UserLog.LoggedUser.TypeId == (int)TypeCodes.Admin) AdminMenu.Print(); break;
                    case 'E': Environment.Exit(0); break;
                    default: break;
                }
            }
        }
    }
}

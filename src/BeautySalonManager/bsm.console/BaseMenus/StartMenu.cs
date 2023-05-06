﻿using bsm.bll;

namespace bsm.console
{
    internal class StartMenu
    {
        public static void Print()
        {
            Console.Clear();
            UserService.AddAdmin();

            Console.WriteLine("[R] Register  [L] Login  [E] Exit");

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

using bsm.bll;

namespace bsm.console
{
    internal class Start
    {
        static void Main(string[] args)
        {
            UserService.AddAdmin();
            MainMenu.Print();
        }
    }
}
using bsm.bll;

namespace bsm.console
{
    internal class AddGroupMenu
    {
        public static void Print()
        {
            Console.Clear();
            Console.WriteLine("Add Group");
            Console.WriteLine();

            string name = Console.ReadLine();

            ServiceGroupService.AddGroup(name);

            Console.WriteLine();
            Console.WriteLine("Group Added");
            Console.ReadKey();
            ServiceEditMenu.Print();
        }
    }
}

namespace BeautySalonsManagement
{
    internal class Employee
    {
        private int _id;
        private string _name;
        private string _workPossition;

        public Employee(string name, string workPossition, int id)
        {
            _id = id;
            _name = name;
            _workPossition = workPossition;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string workPossition { get; set; }
    }
    internal class Client
    {
        private int _id;

        private string _username = null;
        protected string _password = null;
        private string _name = null;
        private string _phoneNumber = null;
        private string _details;

        public Client(string username,
            string passowrd,
            string name,
            string phoneNumber,
            string details)
        {
            _username = username;
            _password = passowrd;
            _name = name;
            _phoneNumber = phoneNumber;
            _details = details;
        }

        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string details { get; set; }

        public bool isRegistered(string password)
        {
            if (password != null)
                return true;

            return false;
        }
    }

    internal class Salon
    {
        private int _id;
        private string _name;
        private string _details;
        private List<DateTime> _freeHours;
        private List<int> employeesId;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Client Mariya = new Client("MZIlcheva19", "12345678", "Mariya", "088 888 8888", "Details");

            Client Polya = new Client("PDDimitrova19", "12345678", "Polya", "088 888 8888", "Details");

            Employee Ivan = new Employee("Ivan", "Hairdresser", 1);
        }
    }
}
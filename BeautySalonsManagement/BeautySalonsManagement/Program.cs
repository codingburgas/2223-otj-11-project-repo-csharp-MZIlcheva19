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

        public string GetName()
        {
            return _name;
        }

        public string GetWorkPossition()
        {
            return _workPossition;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetWorkPossition(string workPossition)
        {
            _workPossition = workPossition;
        }
    }

    internal class Client
    {
        private int _id;

        private string _username = null;
        protected string _password = null;
        private string _name = null;
        private string _phoneNumber = null;
        private string _details;

        private int _stylistId;
        private DateTime _appointment;     

        public bool isRegistered(string password)
        {
            if (password != null) 
                return true;

            return false;
        }

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

        public int GetStylistId()
        {
            return _stylistId;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDetails()
        {
            return _details;
        }

        public DateTime GetAppointment()
        {
            return _appointment;
        }


        public void SetName(string name)
        {
            _name = name;
        }

        public void SetDetails(string details)
        {
            _details = details; ;
        }

        public void SetAppointment(DateTime appointment)
        {
            _appointment = appointment;
        }
    }

    internal class Salon
    {
        private int _id;
        private string _name;
        private string _details;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
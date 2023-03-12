using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonsManagement.Models
{
    internal class Clients
    {
        private int _id;
        private string _username = null;
        protected string _password = null;
        private string _name = null;
        private string _phoneNumber = null;
        private string _details;

        public Clients(int id, string username, string passowrd, string name, string phoneNumber, string details)
        {
            _id = id;
            _username = username;
            _password = passowrd;
            _name = name;
            _phoneNumber = phoneNumber;
            _details = details;
        }

        public int id { get; set; }
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonsManagement.Models
{
    internal class Salons
    {
        private int _id;
        private string _name;
        private List<int> _employees;
        private List<string> _servicesOffered;
        private List<DateTime> _freeHours;

        public Salons(int id, string name, List<int> employees, List<string> servicesOffered, List<DateTime> freeHours)
        {
            _id = id;
            _name = name;
            _employees = employees;
            _servicesOffered = servicesOffered;
            _freeHours = freeHours;
        }

        public int id { set; get; }
        public string name { set; get; }
        public List<int> employees { set; get; }
        public List<string> servicesOffered { set; get; }
        public List<DateTime> freeHours { set; get; }
    }
}

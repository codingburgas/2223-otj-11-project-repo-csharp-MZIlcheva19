using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonsManagement.Models
{
    internal class Employees
    {
        private int _id;
        private string _name;
        private string _workPossition;

        public Employees(string name, string workPossition, int id)
        {
            _id = id;
            _name = name;
            _workPossition = workPossition;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string workPossition { get; set; }
    }
}

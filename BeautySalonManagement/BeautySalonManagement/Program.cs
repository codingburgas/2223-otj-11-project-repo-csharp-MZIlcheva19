using System;
using System.Collections.Generic;

class Program
{
    public class BeautySalon
    {
        public List<Customer> customers;
        public List<Appointment> appointments;
        public List<Employee> employees;
        public List<Skill> skills;
        public List<Service> services;

        public BeautySalon()
        {
            customers = new List<Customer>();
            appointments = new List<Appointment>();
            employees = new List<Employee>();
            skills = new List<Skill>();
            services = new List<Service>();
        }

        // Customers
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return customers.Find(c => c.Id == id);
        }

        // Appointments
        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public void RemoveAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }

        // Employees
        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeByName(string name)
        {
            return employees.Find(e => e.FirstName == name || e.LastName == name);
        }

        // Skills
        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        public void RemoveSkill(Skill skill)
        {
            skills.Remove(skill);
        }

        public List<Skill> GetSkills()
        {
            return skills;
        }

        // Services
        public void AddService(Service service)
        {
            services.Add(service);
        }

        public void RemoveService(Service service)
        {
            services.Remove(service);
        }

        public List<Service> GetServices()
        {
            return services;
        }
    }

    public class Customer
    {
        public List<Customer> customers;

        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(int id, string firstName, string lastName, string username, string password, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }

    public class Employee
    {
        public int Id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public List<Skill> Skills { get; set; }

        public Employee(int id, string firstName, string lastName, string username, string password, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }

    public class Appointment
    {
        int Id;
        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public Service Service { get; set; }
        public Employee Employee { get; set; }

        public Appointment(int id, Customer customer, DateTime dateTime, Service service, Employee employee)
        {
            Id = id;
            Customer = customer;
            DateTime = dateTime;
            Service = service;
            Employee = employee;
        }
    }

    public class Skill
    {
        int Id;
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Skill(int id, string name, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
    }

    public class Service
    {
        int Id;
        public string Name { get; set; }
        public int Price { get; set; }

        public Service(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
    static void Main(string[] args)
    {
        // Create new beauty salon
        BeautySalon salon = new BeautySalon();

        // Add customer
        Customer customer = new Customer(1, "Mariya", "Ilcheva", "milcheva", "password", "088 888 888");
        salon.AddCustomer(customer);

        // Add employee
        Employee employee = new Employee(1, "Polya", "Dimitrova", "pdimitrova", "password", "088 888 888");
        salon.AddEmployee(employee);

        // Add service
        Service service = new Service(1, "Haircut", 20);
        salon.AddService(service);

        // Add appointment
        DateTime dateTime = new DateTime(2023, 4, 23, 10, 0, 0);
        Appointment appointment = new Appointment(1, customer, dateTime, service, employee);
        salon.AddAppointment(appointment);

        // Print list of appointments
        Console.WriteLine("Appointments:");
        foreach (Appointment a in salon.GetAppointments())
        {
            Console.WriteLine("Customer: {0} {1}, Employee: {2} {3}, Service: {4}, Date: {5}",
                a.Customer.FirstName, a.Customer.LastName, a.Employee.FirstName, a.Employee.LastName,
                a.Service.Name, a.DateTime);
        }
    }
}
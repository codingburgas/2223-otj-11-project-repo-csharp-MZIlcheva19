using System;
using System.Collections.Generic;

public class BeautySalon
{
    private List<Customer> customers;
    private List<Appointment> appointments;
    private List<Employee> employees;
    private List<Skill> skills;
    private List<Service> services;   

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
    public void AddEmmployee(Employee employee)
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
    private int Id;
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Username { get; set; }
    private string Password { get; set; }
    private string PhoneNumber { get; set; }

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
    private int Id;
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Username { get; set; }
    private string Password { get; set; }
    private string Description { get; set; }
    private string PhoneNumber { get; set; }
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
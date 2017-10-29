using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;

class Program
{
    static void Main()
    {
        List<Dictionary<int, Employee>> employees = new List<Dictionary<int, Employee>>();
        employees.Add(new Dictionary<int, Employee>(){{1, new Employee("Anna",25)}
                    ,{2, new Employee("Steve",38)}
                    ,{3, new Employee("Lily", 62)}});
        employees.Add(new Dictionary<int, Employee>(){{4, new Employee("George", 71)}});
        
        int maxAge = employees.Max(dict =>  dict.Values.Max(employee => employee.age));
        
        Employee oldest = employees.SelectMany(dict => dict.Values).ToList().Where(emp => emp.age == maxAge).FirstOrDefault();
        
        List<Employee> topTwoOldest = employees.SelectMany(dict => dict.Values).OrderByDescending(emp => emp.age).Take(2).ToList();
        
        Console.WriteLine("Oldest employee age: {0}", oldest.age);
        foreach(Employee employee in topTwoOldest) {
          Console.WriteLine("{0} {1}", employee.name, employee.age);
        }
        
    }
}

class Employee
{
   public string name {get; set;}
   public int age {get; set;}
   
   public Employee(string name, int age) {
        this.name = name;
        this.age = age;
   }
} 

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Program {
  public static void Main(string[] args) {
    UserList list = new UserList();
   
    list.Add(new User("John", "Doe", "jdoe@gmail.com"));
    list.Add(new User("Jane", "Doe", "janedoe@gmail.com"));
    
    if(list["doe"].Any(user => user != null)) {
      list["doe"].ForEach(user => Console.WriteLine("{0}\n", user));
    } else Console.WriteLine("User not found");
  }
}

class User {
  public string FirstName {get; private set;}
  public string LastName {get; private set;}
  public string Email {get; private set;}
  
  public User(string fName, string lName, string email) {
    FirstName = fName;
    LastName= lName;
    Email = email;
  }
  
  public override string ToString() {
    return "Last Name: " + LastName + "\nFirst Name: " + LastName + "\nEmail: " + Email;
  }
}

class UserList {
  private List<User> userList {get; set;}
  
  public UserList() {
    userList = new List<User>();
  }
  
  public void Add(User user) {
    userList.Add(user);
  }
  
  public User this[int index] {
    get {
      if(index >= 0 && index <= userList.Count-1) {
        return userList[index];
      } else throw new IndexOutOfRangeException("Index is out of bounds");
    }
  }
  
  public List<User> this[string Search] {
    get {
      Regex rgx = new Regex(Search, RegexOptions.IgnoreCase);
      return userList.FindAll(user => rgx.IsMatch(user.Email) || rgx.IsMatch(user.FirstName) || rgx.IsMatch(user.LastName));
    }
  }
  
  
}

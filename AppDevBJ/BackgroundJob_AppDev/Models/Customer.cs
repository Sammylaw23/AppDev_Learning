using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev.Models
{
    public class Customer
    {
        
      public int Id {get;set;} 
      public string LastName {get;set;}
      public string FirstName {get;set;}
      public char Gender {get;set;}
      public string Email {get;set;}
      public char EmailSent {get;set;}
      public DateTime DateSent {get;set;}
    }
}

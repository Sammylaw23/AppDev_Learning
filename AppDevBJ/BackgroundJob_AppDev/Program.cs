using BackgroundJob_AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            List<Customer> customers = notifier.SendNotifications();

            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateCustomersRecords(customers);
        }
    }
}

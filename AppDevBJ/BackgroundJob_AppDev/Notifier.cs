using BackgroundJob_AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev
{
    internal class Notifier
    {
        Admin admin;
        Emailer emailer;
        List<Customer> customers;
        internal List<Customer> SendNotifications()
        {
            try
            {
                DataAccess _db = new DataAccess();

                customers = _db.SpoolCustomers();

                if (customers.Count > 0)
                {
                    admin = new Admin();
                       emailer = new Emailer(admin);

                    foreach (var customer in customers)
                    {
                        bool sent = emailer.SendEmailGmail(customer.Email, "Month End Appreciation",
                            $"Thank you {customer.FirstName} for being our esteemed customer");

                        if (sent)
                        {
                            customer.EmailSent = Convert.ToChar("1");
                            customer.DateSent = DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return customers;
        }
    }

}


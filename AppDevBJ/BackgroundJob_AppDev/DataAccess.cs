using BackgroundJob_AppDev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev
{
    public class DataAccess
    {
        Utilities utilities = new Utilities();

       
        public List<Customer> SpoolCustomers()
        {
            var dtCustomers = utilities.GetCustomers();
            return dtCustomers;
        }

        public void UpdateCustomersRecords(List<Customer> customers)
        {
            try
            {
                foreach (var customer in customers)
                {
                    if (customer.EmailSent == '0') 
                        //Work smart, there is no need updating the table if the status has not changed.
                        continue;

                    utilities.UpdateCustomer(customer);

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

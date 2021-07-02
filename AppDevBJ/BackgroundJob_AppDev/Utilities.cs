using BackgroundJob_AppDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJob_AppDev
{
    public class Utilities
    {
        Customer customer;
        List<Customer> customers;
        public List<Customer> GetCustomersN()
        {
            //Don't do this
            //1. Use stored procedures
            //2. Select only the columns you want for better performance and security
            DataTable dt = new DataTable();
            string CustomerDbconnectionString = ConfigurationManager.AppSettings["CustomerDbconnectionString"];
            //SqlConnection sqlConnection = new SqlConnection(CustomerDbconnectionString);
            string selectQuery = "Select * from Customers";
            //SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectQuery, CustomerDbconnectionString);
            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                customer = new Customer();
                customers = new List<Customer>();

                foreach (DataRow row in dt.Rows)
                {

                    customer.Id = Convert.ToInt32(row["Id"].ToString());
                    customer.LastName = row["LastName"].ToString();
                    customer.FirstName = row["FirstName"].ToString();
                    customer.Gender = Convert.ToChar(row["Gender"].ToString());
                    customer.Email = row["Email"].ToString();
                    customer.EmailSent = Convert.ToChar(row["EmailSent"].ToString());
                    customer.DateSent = Convert.ToDateTime(row["DateSent"].ToString());

                    customers.Add(customer);

                }
            }
            return customers;


        }


        public List<Customer> GetCustomers()
        {
            try
            {
                //Don't do this
                //1. Use stored procedures
                //2. Select only the columns you want for better performance and security
                DataTable dt = new DataTable();
                string CustomerDbconnectionString = ConfigurationManager.AppSettings["CustomerDbconnectionString"];
                SqlConnection sqlConnection = new SqlConnection(CustomerDbconnectionString);
                string selectQuery = "Select * from Customers";
                //string selectQuery = "Select Id,LastName,FirstName,Gender,Email,EmailSent,DateSent from Customers";
                SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    customer = new Customer();
                    customers = new List<Customer>();

                    while (sqlDataReader.Read())
                    {
                        customer.Id =  Convert.ToInt32(sqlDataReader["Id"] as string);
                        customer.LastName = sqlDataReader["LastName"].ToString();
                        customer.FirstName = sqlDataReader["FirstName"].ToString();
                        customer.Gender = Convert.ToChar(sqlDataReader["Gender"].ToString());
                        customer.Email = sqlDataReader["Email"].ToString();
                        customer.EmailSent = Convert.ToChar(sqlDataReader["EmailSent"].ToString());
                        customer.DateSent =  Convert.ToDateTime(sqlDataReader["DateSent"] as DateTime? ?? default(DateTime));

                        customers.Add(customer);
                    }
                }
                //else
                //{

                //}


                return customers;
            }
            catch (Exception ex)
            {
                //Properly handle this error
                return null;
            }
            


        }
    
        public void UpdateCustomer(Customer customer)
        {
            
            string updateQuery = "Update Customers set EmailSent = '1',DateSent = getdate() where Id = 1";

        }
    
    }
}

using CustomersWebApp.Models;
using System.Diagnostics.Metrics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CustomersApp.Data
{
    public  class CustomersData
    {
        private  List<Customer> Customers;
        private String fileName = "C:\\VisualStudioProjects\\Data\\Customers.csv";
        //private String fileName = "C:\\VisualStudioProjects\\Data\\SampleData.csv";

        public CustomersData()
        {
            Customers = new List<Customer>();
            var csvRows = System.IO.File.ReadAllLines(fileName, Encoding.Default).ToList();

            foreach (var row in csvRows)
            {
                String[] columns  = row.Split(',');
                if (columns[0].Length>0)
                {
                    Customers.Add(new Customer() { Id = Int32.Parse(columns[0]), Name = columns[1], Address = columns[2], City = columns[3], PostCode = columns[4], Country = columns[5], Phone = columns[6] });
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            return Customers;
        }

        public Customer? Get(int? Id)
        {
            if (Id == null)
            {
                return null;
            }
            List<Customer> Customers = GetCustomers();
            Customer? Customer = null;

            foreach (Customer Customer1 in Customers)
            {
                if (Customer1.Id == Id)
                {
                    Customer = Customer1;
                }
            }
            return Customer;
        }

        public Customer? Update(Customer? Customer)
        {
            if (Customer != null)
            {
                var csv = new StringBuilder();

                for (int i=0; i<Customers.Count; i++)
                {
                    if (Customers[i].Id == Customer.Id)
                    {
                        Customers[i].Name = Customer.Name;
                        Customers[i].Address = Customer.Address;
                        Customers[i].City = Customer.City;
                        Customers[i].PostCode = Customer.PostCode;
                        Customers[i].Country = Customer.Country;
                        Customers[i].Phone = Customer.Phone;

                    }
                    csv.AppendLine(Customers[i].Id + "," + Customers[i].Name + "," + Customers[i].Address + "," + Customers[i].City + "," + Customers[i].PostCode + "," + Customers[i].Country + "," + Customers[i].Phone);
                }
                File.WriteAllText(fileName, csv.ToString());
            }

            return Customer;
        }

        public void Create(Customer Customer)
        {
            var csv = new StringBuilder();
            int maxId = -1;
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id >maxId )
                {
                    maxId = Customers[i].Id;
                }
                csv.AppendLine(Customers[i].Id + "," + Customers[i].Name + "," + Customers[i].Address + "," + Customers[i].City + "," + Customers[i].PostCode + "," + Customers[i].Country + "," + Customers[i].Phone);
            }

            csv.AppendLine(maxId + 1 + "," + Customer.Name + "," + Customer.Address + "," + Customer.City + "," + Customer.PostCode + "," + Customer.Country + "," + Customer.Phone);
            File.WriteAllText(fileName, csv.ToString());
        }

        public void Remove(int Id)
        {
            var csv = new StringBuilder();
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id != Id)
                {
                    csv.AppendLine(Customers[i].Id + 1 + "," + Customers[i].Name + "," + Customers[i].Address + "," + Customers[i].City + "," + Customers[i].PostCode + "," + Customers[i].Country + "," + Customers[i].Phone);
                }
            }
            File.WriteAllText(fileName, csv.ToString());
        }
        
    }
}

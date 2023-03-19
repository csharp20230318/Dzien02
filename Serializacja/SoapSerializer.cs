using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Serializacja
{
    internal class SoapSerializer
    {
        public static void Create()
        {
            EmployeeSoap emp1 = new EmployeeSoap()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2021, 1,1)
            };
            EmployeeSoap emp2 = new EmployeeSoap()
            {
                Id = 123,
                FirstName = "Zenon",
                LastName = "Nowak",
                IsManager = true,
                StartAt = new DateTime(2022, 1, 1)
            };
            EmployeeSoap emp3 = new EmployeeSoap()
            {
                Id = 123,
                FirstName = "Marek",
                LastName = "Zielinski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            //emp.SetToken(Guid.NewGuid().ToString());
            EmployeeSoap[] empArray = new EmployeeSoap[]
            {
                emp1, emp2, emp3
            };

            // serializacja
            using (FileStream fs = new FileStream("soap.xml", FileMode.Create))
            {
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, empArray);
            }

            // deserializacja
            using (FileStream fs = new FileStream("soap.xml", FileMode.Open))
            {
                SoapFormatter sf = new SoapFormatter();
                EmployeeSoap[] emps = sf.Deserialize(fs) as EmployeeSoap[];
                if (emps != null)
                {
                    Console.WriteLine(emps.Length);
                }
            }


        }

    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;


namespace Serializacja
{
    internal class JsonSerializer1
    {
        public static void Create()
        {
            EmployeeJson emp1 = new EmployeeJson()
            {
                Id = 123,
                FirstName = "Jan",
                LastName = "Kowalski",
                IsManager = false,
                StartAt = new DateTime(2021, 1,1)
            };
            EmployeeJson emp2 = new EmployeeJson()
            {
                Id = 123,
                FirstName = "Zenon",
                LastName = "Nowak",
                IsManager = true,
                StartAt = new DateTime(2022, 1, 1)
            };
            EmployeeJson emp3 = new EmployeeJson()
            {
                Id = 123,
                FirstName = "Marek",
                LastName = "Zielinski",
                IsManager = false,
                StartAt = new DateTime(2022, 1, 1)
            };
            //emp.SetToken(Guid.NewGuid().ToString());
            EmployeeJson[] empArray = new EmployeeJson[]
            {
                emp1, emp2, emp3
            };

            // serializacja
            using (FileStream fs = new FileStream("json1.json", FileMode.Create))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EmployeeJson[]));
                serializer.WriteObject(fs, empArray);
            }

            // deserializacja
            using (FileStream fs = new FileStream("json1.json", FileMode.Open))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(EmployeeJson[]));
                EmployeeJson[] emps = serializer.ReadObject(fs) as EmployeeJson[];
                if (emps != null)
                {
                    Console.WriteLine(emps.Length);
                }
            }


        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serializacja
{
    [Serializable]
    public class EmployeeXML
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("fn")]
        public string FirstName { get; set; }
        [XmlElement("ln")]
        public string LastName { get; set; }
        public bool? IsManager { get; set; }
        
        public List<int> AccessRooms { get; set; }
        public DateTime StartAt { get; set; }

        [XmlIgnore]
        public List<string> ExtraData { get; set; }

        private string Token;

        public void SetToken(string token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}

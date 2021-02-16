using BancoSuico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSuico.Model
{
    public class Risk: iRisk
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public string Operator { get; set; }

        public string ClientSector { get; set; }


        public Risk(string Name, double  Value, string Operator,  string ClientSector)
        {
            this.Name = Name;
            this.Value = Value;
            this.Operator = Operator;
            this.ClientSector = ClientSector;
        }
    }
}

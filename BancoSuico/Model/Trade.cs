using BancoSuico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSuico.Model
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }

        public Trade(Double Value, string ClientSector)
        {
            this.Value = Value;
            this.ClientSector = ClientSector;
        }
    }
}

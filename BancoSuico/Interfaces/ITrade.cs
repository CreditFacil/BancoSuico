using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSuico.Interfaces
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }

    }

}

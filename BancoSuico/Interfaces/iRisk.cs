using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSuico.Interfaces
{
    public interface iRisk
    {
        string Name { get; }

        double Value { get; }

        string Operator { get; }

        string ClientSector { get; }

    }
}

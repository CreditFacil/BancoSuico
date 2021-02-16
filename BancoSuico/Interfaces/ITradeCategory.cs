using System;
using System.Collections.Generic;
using System.Text;

namespace BancoSuico.Interfaces
{
    public interface ITradeCategory
    {
       List<string> ReturnTradeCategories(List<ITrade> portfolio);

 string ReturnRisk(ITrade trade);


    }
}

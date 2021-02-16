using BancoSuico.Business;
using BancoSuico.Interfaces;
using BancoSuico.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoSuico
{
  
    //.....

 
    class Program
    {

        static void Main(string[] args)
        {
      
            TradeCategory oTrade = new TradeCategory();
            List<ITrade> portfolio = new List<ITrade>();

            portfolio.Add(new Trade(2000000, "Private"));
            portfolio.Add(new Trade(400000, "Public"));
            portfolio.Add(new Trade(500000, "Public"));
            portfolio.Add(new Trade(3000000, "Public"));
            portfolio.Add(new Trade(5000, "Public"));

            List<string> tradeCategories = oTrade.ReturnTradeCategories(portfolio);

            foreach (string risk in tradeCategories)
            {
                Console.WriteLine(risk);
            }
        }
    }
}

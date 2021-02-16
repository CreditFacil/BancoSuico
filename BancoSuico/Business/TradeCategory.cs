using BancoSuico.Interfaces;
using BancoSuico.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BancoSuico.Business
{
    public class TradeCategory : ITradeCategory
    {
        private List<iRisk> riskCategory = new List<iRisk>();
        public TradeCategory()
        {
            riskCategory.Add(new Risk("LOWRISK", 1000000, "<", "Public"));
            riskCategory.Add(new Risk("MEDIUMRISK", 1000000, ">", "Public"));
            riskCategory.Add(new Risk("HIGHRISK", 1000000, ">", "Private"));
        }

        public List<string> ReturnTradeCategories(List<ITrade> portfolio)
        {
            List<string> tradeCategories = new List<string>();

            foreach (ITrade trade in portfolio)
            {
                tradeCategories.Add(ReturnRisk(trade));
            }

            return tradeCategories;
        }


        public string ReturnRisk(ITrade trade)
        {
            foreach (iRisk risk in riskCategory.FindAll(x => x.ClientSector.Trim().ToUpper()== trade.ClientSector.Trim().ToUpper()))
            {
                switch (risk.Operator)
                {
                    case "<":
                        if (trade.Value < risk.Value)
                            return risk.Name;
                        break;
                    case ">":
                        if (trade.Value > risk.Value)
                            return risk.Name;
                        break;
                }
            }
            return "undefined";
        }
    }
}

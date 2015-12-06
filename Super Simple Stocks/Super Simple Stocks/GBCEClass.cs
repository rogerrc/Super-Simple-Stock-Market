using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
{
    public static class GBCEClass
    {
        #region ENUMS

        #endregion

        #region Private Members

        #endregion

        #region Public Members

        #endregion

        #region Constructor

        static GBCEClass() { }

        #endregion

        #region Methods

        /// <summary>
        /// Calculate the GBCE All Share Index using the geometric mean of prices for all stocks.
        /// https://www.easycalculation.com/statistics/geometric-mean.php further info I found about the calculation.
        /// </summary>
        /// <returns></returns>
        public static double GeometricMean(IList<Stock> stockItemList)
        {

            double mean = 0;
            int n = stockItemList.Count();
            foreach (Stock stockItem in stockItemList)
            {
                mean += stockItem.Trades.LastOrDefault().TradePrice;
            }
            double geometricMean = Math.Pow(mean, 1.0 / n);
            return geometricMean;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
{
    class SuperSimpleStocksClass
    {
        static void Main(string[] args)
        {
            #region Reading Material and Test Help
            
            /*
                http://www.codeproject.com/Articles/553206/An-Introduction-to-Real-Time-Stock-Market-Data-Pro
                https://www.easycalculation.com/statistics/geometric-mean.php
                http://budgeting.thenest.com/calculate-volume-weighted-average-price-26263.html

            */
           
            #endregion

            //Re-Create the table in Sample data from the Global Beverage Corporation Exchange as a List to hold the values for each stock call.
            IList<Stock> stockList = new List<Stock>();
            stockList.Add(new Stock("TEA", Stock.StockType.COMMON, 0, 0.0, 100));
            stockList.Add(new Stock("POP", Stock.StockType.COMMON, 8, 0.0, 100));
            stockList.Add(new Stock("ALE", Stock.StockType.COMMON, 23, 0.0, 60));
            stockList.Add(new Stock("GIN", Stock.StockType.PREFFERED, 8, 2, 100));
            stockList.Add(new Stock("JOE", Stock.StockType.COMMON, 13, 0.0, 250));

            foreach (Stock stockItem in stockList)
            {
                // Calculate Dividend Yield and P/E Ratio.
                double price = 12.5; // price input.
                Console.WriteLine("For stock " + stockItem.StockSymbol);
                double dividendYield = stockItem.DividendYield(price);
                double peRatio = stockItem.PERatio(price);
                Console.WriteLine("The Dividend Yield is: " + dividendYield);
                Console.WriteLine("The P/E Ratio is: " + peRatio);

                // Record stock trades.
                for (int quantity = 1; quantity < 6; quantity++) // Quantity could potentially be randomised too.
                {
                    Random rand = new Random();
                    int randomPrice = rand.Next(10); // Random price for buying.
                    stockItem.BuyStockTrade(DateTime.Now, quantity, randomPrice);
                    Console.WriteLine("Bought: " + quantity + " shares at " + randomPrice + " pennies on " + DateTime.Now);
                    randomPrice = rand.Next(10); // New random price for selling.
                    stockItem.SellStockTrade(DateTime.Now, quantity, randomPrice);
                    Console.WriteLine("Sold : " + quantity + " shares at " + randomPrice + " pennies on " + DateTime.Now);
                    System.Threading.Thread.Sleep(1000); // Slow down the run process so there is a difference in the timestamp.
                }

                // Calculate Volume Weighted Stock Price based on trades in past 15 minutes.
                Console.WriteLine("The Volume Weighted Stock Price based on trades in past 15 minutes is: " + Math.Round(stockItem.VolumeWeightedStockPrice(), 2));
            }

            // Calculate the GBCE All Share Index using the geometric mean of prices for all stocks.
            Console.WriteLine("The GBCE All Share Index: " + GBCEClass.GeometricMean(stockList));

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

    }
}

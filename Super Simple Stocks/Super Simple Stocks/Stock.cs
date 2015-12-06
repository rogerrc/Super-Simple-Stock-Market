using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
{
    /// <summary>
    ///     Define the items that are required for a Stock by using the table provided.
    ///     Stock Symbol, Type, Last Dividend, Fixed Dividend, Par Value.
    /// </summary>
    public class Stock
    {
        #region ENUMS

            public enum StockType
            {
                COMMON,
                PREFFERED
            };

        #endregion

        #region Private Members

            private string _stockSymbol;
            private StockType _type;
            private double _lastDividend;
            private double _fixedDividend;
            private double _parValue;
            private IList<Trade> _trades;

        #endregion

        #region Public Members

            public string StockSymbol
            {
                get
                {
                    return _stockSymbol;
                }

                set
                {
                    _stockSymbol = value;
                }
            }

            public StockType Type
            {
                get
                {
                    return _type;
                }

                set
                {
                    _type = value;
                }
            }

            public double LastDividend
            {
                get
                {
                    return _lastDividend;
                }

                set
                {
                    _lastDividend = value;
                }
            }

            public double FixedDividend
            {
                get
                {
                    return _fixedDividend;
                }

                set
                {
                    _fixedDividend = value;
                }
            }

            public double ParValue
            {
                get
                {
                    return _parValue;
                }

                set
                {
                    _parValue = value;
                }
            }

            public IList<Trade> Trades
            {
                get
                {
                    return _trades;
                }

                set
                {
                    _trades = value;
                }
            }

        #endregion

        #region Constructor

            public Stock(string stockSymbol, StockType type, double lastDividend, double fixedDividend, double parValue)
            {
                StockSymbol = stockSymbol;
                Type = type;
                LastDividend = lastDividend;
                FixedDividend = fixedDividend;
                ParValue = parValue;
                Trades = new List<Trade>();
            }

        #endregion

        #region Methods

        /// <summary>
        /// Calculate the Dividend Yield using Price and Type.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double DividendYield(double price)
        {
            switch (Type)
            {
                case StockType.COMMON:
                    return LastDividend / price;
                    break;
                case StockType.PREFFERED:
                    return FixedDividend * ParValue / price;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        /// <summary>
        /// Calculate the P/E Ratio using Price and the Dividend.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public double PERatio(double price)
        {
            return price / LastDividend;
        }

        /// <summary>
        /// Record a bought trade against the stock item.
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="quantity"></param>
        /// <param name="tradePrice"></param>
        public void BuyStockTrade(DateTime timeStamp, double quantity, double tradePrice)
        {
            Trade trade = new Trade(timeStamp, quantity, Trade.TradeTypeEnum.BUY, tradePrice);
            Trades.Add(trade);
        }

        /// <summary>
        /// Record a sold trade against the stock item.
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="quantity"></param>
        /// <param name="tradePrice"></param>
        public void SellStockTrade(DateTime timeStamp, double quantity, double tradePrice)
        {
            Trade trade = new Trade(timeStamp, quantity, Trade.TradeTypeEnum.SELL, tradePrice);
            Trades.Add(trade);
        }

        /// <summary>
        /// Calculate the Volume Weighted Stock Price based on trades in past 15 minutes.
        /// </summary>
        /// <returns></returns>
        public double VolumeWeightedStockPrice()
        {
            // According to the formula provided, calculate the VWSP by the SUM of the Traded Price times the Quantity divided by the SUM of the quantities during the last 15 minutes.
            IList<Trade> newTrades = Trades.Where(t => t.TimeStamp >= DateTime.Now.AddMinutes(-15)).ToList(); // Trades 15 minutes ago.

            // Get the sum of the trades.
            double sumQuantity = 0;
            double sumPriceTimesQuantity = 0;
            foreach (Trade trade in newTrades)
            {
                sumPriceTimesQuantity += trade.TradePrice * trade.Quantity;
                sumQuantity += trade.Quantity;
            }
            return sumPriceTimesQuantity / sumQuantity;
        }

        #endregion
    }
}

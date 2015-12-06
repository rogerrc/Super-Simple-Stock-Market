using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
{
    public class Trade
    {
        #region ENUMS

            public enum TradeTypeEnum
            {
                BUY, SELL
            }

        #endregion

        #region Private Members

            private DateTime _timeStamp;
            private double _quantity;
            private TradeTypeEnum _tradeType;
            private double _tradePrice;

        #endregion

        #region Public Members

            public DateTime TimeStamp
            {
                get
                {
                    return _timeStamp;
                }

                set
                {
                    _timeStamp = value;
                }
            }

            public double Quantity
            {
                get
                {
                    return _quantity;
                }

                set
                {
                    _quantity = value;
                }
            }

            public TradeTypeEnum TradeType
            {
                get
                {
                    return _tradeType;
                }

                set
                {
                    _tradeType = value;
                }
            }

            public double TradePrice
            {
                get
                {
                    return _tradePrice;
                }

                set
                {
                    _tradePrice = value;
                }
            }

        #endregion

        #region Constructor
 
            public Trade(DateTime timeStamp, double quantity, TradeTypeEnum tradeType, double tradePrice)
            {
                TimeStamp = timeStamp;
                Quantity = quantity;
                TradeType = tradeType;
                TradePrice = tradePrice;
            }

        #endregion

        #region Methods

        #endregion

    }
}

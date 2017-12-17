using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace StockExchange
{
    public class StockValues
    {
        private List<long> stockValues = new List<long>();
        private long worth = 0;
        private long hiValue = 0;
        private long lowValue = 0;
        public StockValues()
        {
            
        }
        public void Add2(long value)
        {

            if (hiValue < value)
            { 
                this.hiValue = value; 
            }

            if (this.worth > value - this.hiValue)
                this.worth = value - this.hiValue;
            //-1072319731

            //-1072319731
            //-1072319731
        }
        public void Add(long value)
        {
            
            //int valueSoldToday = 0;
            if(this.stockValues.Count() >= 1)
            {
                long diff = value - this.stockValues.Max();
                if (this.worth > diff)
                    this.worth = diff;
                /*
                foreach(int stock in this.stockValues){
                    if(this.worth > value-stock)
                    {
                        this.worth = value - stock;
                    }
                }//
                */
            }
            this.stockValues.Add(value);
        }

        public long getWorseValue()
        {
            if (this.worth > 0)
                return 0;
            else
                return this.worth;

            //-1073730311
        }
    }

}

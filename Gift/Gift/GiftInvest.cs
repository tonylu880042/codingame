using System;
using System.Collections.Generic;
using System.Linq;

namespace Gift
{
    [Serializable()]
    public class ImpossibleException : System.Exception
    {
        public ImpossibleException() : base() { }
        public ImpossibleException(string message) : base(message) { }
        public ImpossibleException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected ImpossibleException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
    public class GiftInvest
    {
        public int totalCost = 0;
        public int participateCount = 0;
        public List<int> odds = new List<int>();

        public GiftInvest()
        {
            
        }
        public void SetBudget(int cost)
        {
            this.totalCost = cost;
        }
        public void AddOdds(int cost)
        {
            odds.Add(cost);
        }
        public List<int> Calculate() 
        {
            List<int> result = new List<int>();
            int sum = this.odds.Sum(x => x);
            this.odds.Sort((x, y) => { return x.CompareTo(y); });
            if (sum < this.totalCost)
                throw new ImpossibleException();

            int avg = (int)(this.totalCost / this.odds.Count);
            int left = this.totalCost;
            int peopleCount = 0;
            foreach(var odd in odds)
            {
                peopleCount++;
                if (result.Count>0 &&  result[result.Count - 1] == 69)
                    Console.WriteLine("");
                
                if(odd < avg && left-odd >= 0)
                {
                    result.Add(odd);
                    left = left - odd;
                    if (this.odds.Count - peopleCount > 0)
                        avg = (int)(left / (this.odds.Count - peopleCount));                   
                    continue;
                }

                if(odd >= avg)
                {
                    if (left > avg )
                    {
                        result.Add(avg);
                        left = left - avg;
                    }
                    else
                        result.Add(left);
                }
                else
                    result.Add(left);
                
                if(this.odds.Count - peopleCount > 0)
                    avg =(int) (left / (this.odds.Count - peopleCount));



            }


            return result;
        }
    }
}

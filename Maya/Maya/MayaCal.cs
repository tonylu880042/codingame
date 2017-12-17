using System;
using System.Collections.Generic;
using System.Text;

namespace Maya
{
    public class MayaDigi {
        public static List<MayaDigi> mDigis = new List<MayaDigi>();
        public long digi = -1;
        public int index = 0;
        public List<string> text = new List<string>();
        public int width, height;

        public string[] GetDigi(int numberofdigi)
        {
            string[] result = new string[this.height];
            for (int i = 0; i < text.Count;i++)
            {
                if (i > (numberofdigi - 1) * this.height && i < numberofdigi * this.height)
                    result[i] = text[i];
            }
            return result;
        }
        public MayaDigi(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
        public void AddSymbol(string symbol)
        {
            text.Add(symbol);
            index++;
        }
        public bool isSame(string[] target)
        {
            bool result = true;
            for (int i = 0; i < this.height; i++)
            {
                if (this.text[i] != target[i])
                {
                    result = false;
                    break;
                }
            }//
            return result;
        }
        public bool isSame(MayaDigi target)
        {
            bool result = true;
            for (int i = 0; i < this.height; i++)
            {
                if (this.text[i] != target.text[i])
                { 
                    result = false;
                    break;
                }
            }
            return result;
        }
        public void Translate()
        {
            List<long> dataSet = new List<long>();
            for (int i = 0; i < (int)(this.text.Count / this.height);i++)
            {
                string[] subDigi = new string[this.height];
                for (int j = 0; j < this.height;j++)
                {
                    subDigi[j] = this.text[i * this.height + j];
                }
                dataSet.Add(MayaDigi.Recognize(subDigi));
            }
            //
            long result = 0;
            for (int i = dataSet.Count - 1; i >= 0; i--)
            {
                long d = dataSet[i];
                if (dataSet.Count - 1 - i == 0)
                {
                    result = result + d;
                }
                else
                {
                    int pow = 1;
                    for (int j = 0; j < dataSet.Count - 1 - i; j++)
                        pow = 20 * pow;
                    result = result + pow * d;
                }
            }
            this.digi = result;

        }
        public static long Recognize(string[] d)
        {

            foreach (MayaDigi digi in MayaDigi.mDigis)
            {
                if (digi.isSame(d) == true)
                {
                    return digi.digi;
                }
            }
            return -1;
        }
              
    }
    public class MayaCal
    {
        
        public int width = 0;
        public int height = 0;
        public MayaCal(int width,int height)
        {
            this.width = width;
            this.height = height;

            MayaDigi.mDigis.Clear();

            for (int i = 0; i < 20;i++)
            {
                MayaDigi md = new MayaDigi(width,height);
                md.digi = i;
                MayaDigi.mDigis.Add(md);
            }
        }
        public long Recognize(MayaDigi md)
        {
            md.Translate();
            return md.digi;
        }
        public void Init(String data)
        {
            MayaDigi md = null;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= data.ToCharArray().Length;i++)
            {
                sb.Append(data.ToCharArray()[i-1]);   
                if (i % this.width == 0){                    
                    md = MayaDigi.mDigis[(int)(i / this.width)-1]; 
                    md.AddSymbol(sb.ToString());
                    sb.Clear();
                }                                                 
            }
        }
        public MayaDigi MakeMayaDigi(string[] symbol)
        {
            MayaDigi md = new MayaDigi(this.width,this.height);

            foreach(string d in symbol)
                md.AddSymbol(d);
            return md;
        }


        public string[] Caculate(MayaDigi d1, MayaDigi d2, string op)
        {
            long result = 0;
            switch(op)
            {
                case "+":
                    result = d1.digi + d2.digi;
                    break;
                case "-":
                    result = d1.digi - d2.digi;
                    break;
                case "*":
                    result = d1.digi * d2.digi;
                    break;
                case "/":
                    result = (int)(d1.digi / d2.digi);
                    break;
            }//switch

            List<long> answer = new List<long>();

            long quotient = result;

            if (quotient > 20)
            {
                while (quotient > 20)
                {
                    answer.Add(quotient % 20);
                    quotient = quotient / 20;
                }
                answer.Add(quotient % 20);
            }
            else
                answer.Add(result);
            string[] output = new string[answer.Count * this.height];
            //
            for (int i = answer.Count - 1; i >= 0;i--)
            {
                long digi = answer[i];
                for (int j = 0; j < this.height;j++)
                {
                    output[(answer.Count-i-1)*this.height+j] =MayaDigi.mDigis[(int)digi].text[j];  
                } 
            }

            return output;
        }

    }
}

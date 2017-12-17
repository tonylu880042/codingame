using System;
using System.Collections.Generic;

namespace Conway
{
    public class Semantics{
        public int count = 0;
        public string digi = "";
        public override String ToString(){
            return string.Format("{0}{1}", this.count, this.digi);
        }
    }
    public class ConwayGenerator
    {
        public ConwayGenerator()
        {
        }

        public string Generator(int R, int L){

            string result = R.ToString();
            List<Semantics> tokens = new List<Semantics>();
            Semantics current = null;
            for (int i = 0; i < L-1; i++)
            {
                String[] data = result.Split(' ');
                                    
                for (int j = 0; j < data.Length;j++)
                {
                    if (current == null)
                    {
                        current = new Semantics();
                        current.digi = data[j];
                        current.count++;
                        tokens.Add(current);
                    }
                    else{

                        if (current.digi == data[j]){
                            current.count++;   
                        }                            
                        else
                        {
                            current = new Semantics();
                            current.count++;
                            current.digi = data[j];
                            tokens.Add(current);
                        }
                    }                                        
                }//for j

                string output = "";
                foreach (Semantics s in tokens)
                {
                    output = output + " " + s.count.ToString() + " " + s.digi.ToString();
                }
                Console.WriteLine(result);
                result = output.Trim();
                current = null;
                tokens.Clear();

            }//for i

            Console.WriteLine(result);

            return result.Trim();

        }//Generator

    }
}

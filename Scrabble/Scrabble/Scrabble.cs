using System;
using System.Collections.Generic;
using System.Linq;
namespace Scrabble
{   
    public class Alphabet {
       public char c;
       public int count;
    }
    public class Word{
        public int order;
        public string data;
        public List<char> alphbets = new List<char>();
        public List<Alphabet> repeats = new List<Alphabet>();
        public int score;
        public void GenerateAlphbets()
        {
            List<char> result =data.ToList().OrderBy(a => a).ToList();

            for (int i = result.Count() - 1; i >= 0;i--)
            {
                if (i - 1 >= 0 && result[i] == result[i - 1])
                {
                    
                    Alphabet c = this.repeats.Find(x => x.c == result[i]);
                    if (c != null)
                    {
                        c.count++;
                    }
                    else{
                        c = new Alphabet();
                        c.c = result[i];
                        c.count = 1;
                        this.repeats.Add(c);
                    }
                    result.RemoveAt(i);
                }
            }

            this.alphbets = result;
        }
    }

    public class ScrabbleDict
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        Dictionary<string, int> words = new Dictionary<string, int>();
        List<Word> inputs = new List<Word>();
        Word limitChars = null;
        public void SetupLimits(string limit)
        {
            limitChars = new Word();
            limitChars.data = limit;
            this.limitChars.GenerateAlphbets();
        }
        public ScrabbleDict()
        {
            dict.Add("e",1);
            dict.Add("a", 1);
            dict.Add("i", 1);
            dict.Add("o", 1);
            dict.Add("n", 1);
            dict.Add("r", 1);
            dict.Add("t", 1);
            dict.Add("l", 1);
            dict.Add("s", 1);
            dict.Add("u", 1);

            dict.Add("d", 2);
            dict.Add("g", 2);

            dict.Add("b", 3);
            dict.Add("c", 3);
            dict.Add("m", 3);
            dict.Add("p", 3);

            dict.Add("f", 4);
            dict.Add("h", 4);
            dict.Add("v", 4);
            dict.Add("w", 4);
            dict.Add("y", 4);

            dict.Add("k", 5);

            dict.Add("j", 8);
            dict.Add("x", 8);

            dict.Add("q", 10);
            dict.Add("z", 10);
        }

        public int Score(List<char> words)
        {
            //char[] charArray = word.ToCharArray();
            int score = 0;
            //

            foreach(char c in words){
                score = score + this.dict[c.ToString()];
            }
            return score;
        }

        public void AddWord(string word)
        {
            Word w = new Word();
            w.data = word;
            w.order = inputs.Count();
            w.GenerateAlphbets();
            inputs.Add(w);
        }
        public string GetHighestScoreWord()
        {
            //
            for (int i = inputs.Count-1; i >= 0;i--)
            {
                Word word = inputs[i];
                List<char> target = word.alphbets;
                var isSubset = target.Intersect(limitChars.alphbets);  

                if(isSubset.Count() < target.Count())
                {
                    inputs.Remove(word);
                    continue;
                }
                else{

                    if (word.repeats.Count() > this.limitChars.repeats.Count())
                    {
                        inputs.Remove(word);
                        continue;
                    }//if                        
                }

                word.score = this.Score(word.alphbets);

            }

            var items = from w in inputs
                orderby w.score descending,w.order ascending 
                        select w;
            string result = "";
            foreach (var w in items)
            {
                result = w.data;
                break;
            }
            return result;
        }
    }
}

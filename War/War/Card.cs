using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace War
{
    public class Card:IComparer
    {
        public string name { get; set; }
        public int value { get; set; }
        public string suit { get; set; }
        public Card() { }
        public Card(string cid)
        {
            if(cid.Length == 2)
            {    
                this.suit =  cid.Substring(1);
                int n;
                bool isNumeric = int.TryParse(cid.Substring(0, cid.Length - 1), out n);
                if(isNumeric)
                {    
                    this.value = n;
                }
                else{
                    string v = cid.Substring(0, cid.Length - 1);
                    if (v == "A") this.value = 14;
                    if (v == "K") this.value = 13;
                    if (v == "Q") this.value = 12;
                    if (v == "J") this.value = 11;
                }
            }
            else{
                this.suit = cid.Substring(2);
                this.value = int.Parse(cid.Substring(0, cid.Length - 1));
            }


        }
        public string ToString()
        {
            return string.Format("{0}{1}",this.value,this.suit);
        }
        public int Compare(Object x, Object y)
        {
            return ((Card)x).value.CompareTo(((Card)y).value);
        }
    }
    public class Game{
        public string status { get; set; }
        public Queue<Card> play1 { get; set; }
        public Queue<Card> play2 { get; set; }
        public int round { get; set; }
        List<Card> play1PilList;
        List<Card> play2PilList;

        public Game(){
            play1 = new Queue<Card>();
            play2 = new Queue<Card>();
            play1PilList = new List<Card>();
            play2PilList = new List<Card>();
            this.round = 0;
        }
        public void SetPlayerCards(int user, string card)
        {
            string[] tok = { " " };
            string[] cards = card.Split(tok,StringSplitOptions.RemoveEmptyEntries);
            if(user ==1 ){

                for (int i = 0; i < cards.Length;i++){
                    Card c = new Card(cards[i]);
                    play1.Enqueue(c);    
                }//for
            }//if
            else{
                for (int i = 0; i < cards.Length; i++){
                    Card c = new Card(cards[i]);
                    play2.Enqueue(c);
                }//for
            }//else
  
        }
        public void OnPileDown(Card p1,Card p2){

            play1PilList.Add(p1);
            if (play1.Count >= 3){
                play1PilList.Add(play1.Dequeue());
                play1PilList.Add(play1.Dequeue());
                play1PilList.Add(play1.Dequeue());
            }
            else{
                this.status = "pat";
            }
            play2PilList.Add(p2);
            if(play2.Count >= 3){
                play2PilList.Add(play2.Dequeue());
                play2PilList.Add(play2.Dequeue());
                play2PilList.Add(play2.Dequeue());
            }
            else
            {
                this.status = "pat";
            }
        }
        public void OnFight(){

            Card p1 = play1.Dequeue();
            Card p2 = play2.Dequeue();

            if(p1.value == p2.value)
            {
                if (this.status == "fight" )
                    this.round++;
                this.status = "war";

                this.OnPileDown(p1,p2);
            }
            else if (p1.value > p2.value)
            {
                if (this.status == "fight")
                {
                    this.round++;
                    play1.Enqueue(p1);
                    play1.Enqueue(p2);
                    Console.WriteLine("Fight, play1 win");
                }
                else if (status == "war")
                {
                    for (int i = 0; i < this.play1PilList.Count; i++)
                    {
                        play1.Enqueue(this.play1PilList[i]);

                    }
                    play1.Enqueue(p1);

                    for (int i = 0; i < this.play2PilList.Count; i++)
                    {
                        play1.Enqueue(this.play2PilList[i]);

                    }
                    this.status = "fight";
                    play1.Enqueue(p2);
                    Console.WriteLine("War, play1 win");
                    play1PilList.Clear();
                    play2PilList.Clear();
                }
            }
            else
            {
                if (this.status == "fight")
                {
                    this.round++;
                    play2.Enqueue(p1);
                    play2.Enqueue(p2);
                    Console.WriteLine("Fight, play2 win");
                }
                else if (status == "war")
                {
                    for (int i = 0; i < this.play1PilList.Count; i++)
                    {
                        play2.Enqueue(this.play1PilList[i]);

                    }
                    play2.Enqueue(p1);

                    for (int i = 0; i < this.play2PilList.Count; i++)
                    {
                        play2.Enqueue(this.play2PilList[i]);

                    }
                    play2.Enqueue(p2);

                    this.status = "fight";
                    this.play1PilList.Clear();
                    this.play2PilList.Clear();
                    Console.WriteLine("War, play2 win");
                    play1PilList.Clear();
                    play2PilList.Clear();
                }
            }


        }
        public void OnAction(string play1Cards,string play2Cards){


            SetPlayerCards(1, play1Cards);
            SetPlayerCards(2, play2Cards);
            status = "fight";
            while(play1.Count > 0 && play2.Count > 0)
            {
                
                this.OnFight();


                if(this.status == "pat")
                {
                    Console.WriteLine("PAT");
                    return;
                }

                Console.WriteLine(string.Format("Round:{0}",round));
                Console.WriteLine("Play 1");

                StringBuilder sb = new StringBuilder();
                Card[] list = this.play1.ToArray();
                foreach (Card d in list)
                    sb.Append(d.ToString()).Append(" ");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.WriteLine("Play 2");
                list = this.play2.ToArray();
                foreach (Card d in list)
                    sb.Append(d.ToString()).Append(" ");
                Console.WriteLine(sb.ToString());                  

            }//while
            int winner = 0;
            if (play1.Count == 0)
                winner = 2;
            else
                winner = 1;
            System.Console.Write(string.Format("{0} {1}",winner,round));
        }
    }
}

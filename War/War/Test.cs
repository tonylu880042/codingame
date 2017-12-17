using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace War
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void CardParseTest()
        {
            Card c = new Card("10H");
            Card c1 = new Card("KH");
            Assert.True(c1.Compare(c1,c) == 1);
        }
        [Test()]
        public void CardQueueTest()
        {
            
            Queue<Card> play1Deck = new Queue<Card>();
            for (int i = 2; i <= 14;i++)
            {
                Card c = null;
                if(i<= 10)  
                    c = new Card(string.Format("{0}H",i));
                else{
                    if(i == 11) c = new Card("JH");
                    else if (i == 12) c = new Card("QH");
                    else if (i == 13) c = new Card("KH");
                    else if (i == 14) c = new Card("AH");
                }
                play1Deck.Enqueue(c);

            }//for

            Assert.True(play1Deck.Count == 13);
            //pil down three cards
            Card f = play1Deck.Dequeue();
            List<Card> cards = new List<Card>();
            cards.Add(play1Deck.Dequeue());
            cards.Add(play1Deck.Dequeue());
            cards.Add(play1Deck.Dequeue());
            play1Deck.Enqueue(f);
            Assert.True(play1Deck.Count == 10);

        }//CardQueue

        [Test()]
        public void PlaCardTest()
        {
            //string player1Cards = "10H KD 6C 10S 8S AD QS 3D 7H KH 9D 2D JC KS 3S 2S QC AC JH 7D KC 10D 4C AS 5D 5S";
            //string player2Cards = "2H 9C 8C 4S 5C AH JD QH 7C 5H 4H 6H 6S QD 9H 10C 4D JS 6D 3H 8H 3C 7S 9S 8D 2C";
            string player1Cards = "AH 4H 5D 6D QC JS 8S 2D 7D JD JC 6C KS QS 9D 2C 5S 9S 6S 8H AD 4D 2H 2S 7S 8C";
            string player2Cards = "10H 4C 6H 3C KC JH 10C AS 5H KH 10S 9H 9C 8D 5C AC 3H 4S KD 7C 3S QH 10D 3D 7H QD";

            Game game = new Game();
            //game.OnAction( "AD KC QC","KH QS JC");
            game.OnAction(player1Cards,player2Cards);
        }
    }
}

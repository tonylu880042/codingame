using NUnit.Framework;
using System;
using System.Text;

namespace Bender
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase01()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(5, 5);
            env.AddMapData("#####");
            env.AddMapData("#@  #");
            env.AddMapData("#   #");
            env.AddMapData("#  $#");
            env.AddMapData("#####");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while(move !="DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST");

            Assert.AreEqual(output.ToString(),bender.OuptutPath());

        }
        [Test()]
        public void TestCase02()
        {

            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(8, 8);
            env.AddMapData("########");
            env.AddMapData("# @    #");
            env.AddMapData("#     X#");
            env.AddMapData("# XXX  #");
            env.AddMapData("#   XX #");
            env.AddMapData("#   XX #");
            env.AddMapData("#     $#");
            env.AddMapData("########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }
           
            output.AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH");
            

            Assert.AreEqual(output.ToString(), bender.OuptutPath());

        }
        [Test()]
        public void TestCase03()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(8, 8);
            env.AddMapData("########");
            env.AddMapData("#     $#");
            env.AddMapData("#      #");
            env.AddMapData("#      #");
            env.AddMapData("#  @   #");
            env.AddMapData("#      #");
            env.AddMapData("#      #");
            env.AddMapData("########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  ;


            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase04()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(8, 8);
            env.AddMapData("########");
            env.AddMapData("#      #");
            env.AddMapData("# @    #");
            env.AddMapData("# XX   #");
            env.AddMapData("#  XX  #");
            env.AddMapData("#   XX #");
            env.AddMapData("#     $#");
            env.AddMapData("########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  ;
            
            Assert.AreEqual(output.ToString(), bender.OuptutPath());

        }
        [Test()]
        public void TestCase05()
        {
            
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(10, 10);
            env.AddMapData("##########");
            env.AddMapData("#        #");
            env.AddMapData("#  S   W #");
            env.AddMapData("#        #");
            env.AddMapData("#  $     #");
            env.AddMapData("#        #");
            env.AddMapData("#@       #");
            env.AddMapData("#        #");
            env.AddMapData("#E     N #");
            env.AddMapData("##########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase06()
        {
            /*

##########
# @      #
# B      #
#XXX     #
# B      #
#    BXX$#
#XXXXXXXX#
#        #
#        #
##########
            */

            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(10, 10);
            env.AddMapData("##########");
            env.AddMapData("# @      #");
            env.AddMapData("# B      #");
            env.AddMapData("#XXX     #");
            env.AddMapData("# B      #");
            env.AddMapData("#    BXX$#");
            env.AddMapData("#XXXXXXXX#");
            env.AddMapData("#        #");
            env.AddMapData("#        #");
            env.AddMapData("##########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")

                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase07()
        {
            /*
##########
#    I   #
#        #
#       $#
#       @#
#        #
#       I#
#        #
#        #
##########
            */
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(10, 10);
            env.AddMapData("##########");
            env.AddMapData("#    I   #");
            env.AddMapData("#        #");
            env.AddMapData("#       $#");
            env.AddMapData("#       @#");
            env.AddMapData("#        #");
            env.AddMapData("#       I#");
            env.AddMapData("#        #");
            env.AddMapData("#        #");
            env.AddMapData("##########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase08()
        {
            
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(10, 10);
            env.AddMapData("##########");
            env.AddMapData("#    T   #");
            env.AddMapData("#        #");
            env.AddMapData("#        #");
            env.AddMapData("#        #");
            env.AddMapData("#@       #");
            env.AddMapData("#        #");
            env.AddMapData("#        #");
            env.AddMapData("#    T  $#");
            env.AddMapData("##########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase09()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(10, 10);
            env.AddMapData("##########");
            env.AddMapData("#        #");
            env.AddMapData("#  @     #");
            env.AddMapData("#  B     #");
            env.AddMapData("#  S   W #");
            env.AddMapData("# XXX    #");
            env.AddMapData("#  B   N #");
            env.AddMapData("# XXXXXXX#");
            env.AddMapData("#       $#");
            env.AddMapData("##########");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
        [Test()]
        public void TestCase10()
        {            
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(15, 15);
            env.AddMapData("###############");
            env.AddMapData("#      IXXXXX #");
            env.AddMapData("#  @          #");
            env.AddMapData("#             #");
            env.AddMapData("#             #");
            env.AddMapData("#  I          #");
            env.AddMapData("#  B          #");
            env.AddMapData("#  B   S     W#");
            env.AddMapData("#  B   T      #");
            env.AddMapData("#             #");
            env.AddMapData("#         T   #");
            env.AddMapData("#         B   #");
            env.AddMapData("#            $#");
            env.AddMapData("#        XXXX #");
            env.AddMapData("###############");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }
           
            output.AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("NORTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("WEST")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("SOUTH")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  .AppendLine("EAST")
                  ;

            Assert.AreEqual(output.ToString(), bender.OuptutPath());

        }
        [Test()]
        public void TestCase11()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(15, 15);
            env.AddMapData("###############");
            env.AddMapData("#      IXXXXX #");
            env.AddMapData("#  @          #");
            env.AddMapData("#E S          #");
            env.AddMapData("#             #");
            env.AddMapData("#  I          #");
            env.AddMapData("#  B          #");
            env.AddMapData("#  B   S     W#");
            env.AddMapData("#  B   T      #");
            env.AddMapData("#             #");
            env.AddMapData("#         T   #");
            env.AddMapData("#         B   #");
            env.AddMapData("#N          W$#");
            env.AddMapData("#        XXXX #");
            env.AddMapData("###############");
            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }

            output.AppendLine("LOOP");
            Assert.AreEqual(output.ToString(), bender.OuptutPath());
                  
        }
        [Test()]
        public void TestCase12()
        {
            StringBuilder output = new StringBuilder();

            Envornment env = new Envornment(15, 30);

            env.AddMapData("###############");
            env.AddMapData("#  #@#I  T$#  #");
            env.AddMapData("#  #    IB #  #");
            env.AddMapData("#  #     W #  #");
            env.AddMapData("#  #      ##  #");
            env.AddMapData("#  #B XBN# #  #");
            env.AddMapData("#  ##      #  #");
            env.AddMapData("#  #       #  #");
            env.AddMapData("#  #     W #  #");
            env.AddMapData("#  #      ##  #");
            env.AddMapData("#  #B XBN# #  #");
            env.AddMapData("#  ##      #  #");
            env.AddMapData("#  #       #  #");
            env.AddMapData("#  #     W #  #");
            env.AddMapData("#  #      ##  #");
            env.AddMapData("#  #B XBN# #  #");
            env.AddMapData("#  ##      #  #");
            env.AddMapData("#  #       #  #");
            env.AddMapData("#  #       #  #");
            env.AddMapData("#  #      ##  #");
            env.AddMapData("#  #  XBIT #  #");
            env.AddMapData("#  #########  #");
            env.AddMapData("#             #");
            env.AddMapData("# ##### ##### #");
            env.AddMapData("# #     #     #");
            env.AddMapData("# #     #  ## #");
            env.AddMapData("# #     #   # #");
            env.AddMapData("# ##### ##### #");
            env.AddMapData("#             #");
            env.AddMapData("###############");

            env.buildMap();
            Robot bender = new Robot(env);
            string move = "";
            while (move != "DONE" && move != "LOOP")
            {
                move = bender.NextMove();
                Console.WriteLine(move);
            }
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("NORTH");
            output.AppendLine("WEST");
            output.AppendLine("WEST");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("SOUTH");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");
            output.AppendLine("EAST");


            Assert.AreEqual(output.ToString(), bender.OuptutPath());
        }
    }
}

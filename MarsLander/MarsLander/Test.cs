using NUnit.Framework;
using System;
namespace MarsLander
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            World world = new World(9, 28, 0, 0);
            world.InitializePopulation();

            world.NextGeneration();
            world.Mutate();
            world.CrossOver();


        }
    }
}

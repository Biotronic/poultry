using System.Linq;
using Biotronic.Poultry.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biotronic.Poultry.Tests
{
    public class Configuration
    {
        public string ConnectionString { get; set; }
    }

    [TestClass]
    public class BroodTests : TestBase
    {

        [TestMethod]
        public void CreateNewBrood()
        {
            Assert.AreEqual(0, Context.Broods.Count());

            var newBrood = new BroodUpdate
            {

            };

            Repository.UpdateBrood(newBrood);


            Assert.AreEqual(1, Context.Broods.Count());
        }
    }
}

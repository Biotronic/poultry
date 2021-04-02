using System.Collections.Generic;
using System.Linq;
using Biotronic.Poultry.Dto;
using Biotronic.Poultry.Utilities;
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
        [TestInitialize]
        public void Init()
        {
            DeepActivator.Reset();
            DeepActivator.Register((BaseDtoObject o) => o.Id, 0);
            DeepActivator.Register(Action.Create);
        }

        [TestMethod]
        public void CreateNewBrood()
        {
            Repository.UpdateBrood(DeepActivator.CreateInstance<BroodUpdate>());

            Assert.AreEqual(1, Context.Broods.Count());
        }

        [TestMethod]
        public void DeleteBrood()
        {
            Repository.UpdateBrood(DeepActivator.CreateInstance<BroodUpdate>());

            var broodUpdate = new BroodUpdate
            {
                Broods = new List<Brood>
                {
                    new Brood
                    {
                        Id = 1,
                        Action = Action.Delete
                    }
                }
            };

            Repository.UpdateBrood(broodUpdate);

            Assert.AreEqual(0, Context.Broods.Count());
        }

        [TestMethod]
        public void ChangeComment()
        {
            Repository.UpdateBrood(DeepActivator.CreateInstance<BroodUpdate>());

            var broodUpdate = new BroodUpdate
            {
                Broods = new List<Brood>
                {
                    new Brood
                    {
                        Id = 1,
                        Action = Action.None,
                        Comments = new List<BroodComment>
                        {
                            new BroodComment
                            {
                                Id = 1,
                                Action = Action.Update,
                                Comment = "Bar"
                            }
                        }
                    }
                }
            };

            broodUpdate.Broods.First().Comments.First().Brood = broodUpdate.Broods.First();

            Repository.UpdateBrood(broodUpdate);

            Assert.AreEqual("Bar", Context.Broods.First().Comments.First().Comment);
            Assert.AreEqual(1, Context.Broods.First().Days.Count());
        }

        [TestMethod]
        public void AddComment()
        {
            Repository.UpdateBrood(DeepActivator.CreateInstance<BroodUpdate>());

            var broodUpdate = new BroodUpdate
            {
                Broods = new List<Brood>
                {
                    new Brood
                    {
                        Id = 1,
                        Action = Action.None,
                        Comments = new List<BroodComment>
                        {
                            new BroodComment
                            {
                                Action = Action.Create,
                                Comment = "Bar"
                            }
                        }
                    }
                }
            };

            broodUpdate.Broods.First().Comments.First().Brood = broodUpdate.Broods.First();

            Repository.UpdateBrood(broodUpdate);

            Assert.AreEqual("Foo", Context.Broods.First().Comments.First().Comment);
            Assert.AreEqual("Bar", Context.Broods.First().Comments.Last().Comment);
            Assert.AreEqual(1, Context.Broods.First().Days.Count());
        }

        [TestMethod]
        public void UpdatePartial()
        {
            Repository.UpdateBrood(DeepActivator.CreateInstance<BroodUpdate>());
            Assert.AreEqual(1, Context.Broods.First().Comments.Count());

            var broodUpdate = new BroodUpdate
            {
                Broods = new List<Brood>
                {
                    new Brood
                    {
                        Id = 1,
                        Action = Action.Update,
                        Changes = new List<string>{ "BroodNumber" },
                        BroodNumber = 13,
                        FemaleCount = 100
                    }
                }
            };

            Repository.UpdateBrood(broodUpdate);
            Assert.AreEqual(1, Context.Broods.First().Comments.Count());
            Assert.AreEqual(13, Context.Broods.First().BroodNumber);
            Assert.AreEqual(1, Context.Broods.First().FemaleCount);
        }
    }
}

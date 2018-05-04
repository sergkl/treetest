using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;

namespace DataAccess.Tests
{
    [TestClass()]
    public class TestRepositoryTests
    {
        private IRepository repository;

        [TestInitialize()]
        public void Initialize()
        {
            // NOTE: Initialization could be done via IoC like structuremap, unity, ninject etc...
            repository = new TestRepository();
            repository.Initialization(TestData.GetCategories());
        }

        [TestMethod()]
        public void GetCategoryTest()
        {
            // Test a.i
            Category category = repository.GetCategory(201);
            Assert.AreEqual(category.ParentCategoryId, 200);
            Assert.AreEqual(category.Name, "Computer");
            Assert.AreEqual(category.Keywords, "Teaching");

            // Test a.ii
            category = repository.GetCategory(202);
            Assert.AreEqual(category.ParentCategoryId, 201);
            Assert.AreEqual(category.Name, "Operating System");
            Assert.AreEqual(category.Keywords, "Teaching");
        }

        [TestMethod()]
        public void GetCategoryIdsByLevel()
        {
            // Test b.i
            List<int> results = repository.GetCategoryIdsByLevel(2);
            Assert.IsTrue(results.Contains(101) && results.Contains(102) && results.Contains(201) && results.Count == 3);

            // Test b.ii
            results = repository.GetCategoryIdsByLevel(3);
            Assert.IsTrue(results.Contains(103) && results.Contains(109) && results.Contains(202) && results.Count == 3);
        }
    }
}
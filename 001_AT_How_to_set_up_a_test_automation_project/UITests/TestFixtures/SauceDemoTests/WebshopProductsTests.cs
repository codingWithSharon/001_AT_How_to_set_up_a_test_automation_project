using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AT_How_to_set_up_a_test_automation_project.UITests.TestFixtures.SauceDemoTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class WebshopProductsTests
    {
        [Test, Retry(2)]
        public async Task SampleTest_WebshopProducts()
        {
            Console.WriteLine("This is a placeholder test for WebshopProductsTests.");
        }
    }
}

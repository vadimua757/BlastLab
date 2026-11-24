using BlastLab.Domain;
using NUnit.Framework;

namespace BlastLab.Tests
{
    public class AppInfoTests
    {
        [Test]
        public void ProductName_IsNotEmpty() => Assert.IsNotEmpty(AppInfo.ProductName);
    }
}

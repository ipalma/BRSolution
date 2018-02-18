using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Services;
using Models.Models;

namespace ServicesTest
{
    [TestClass]
    public class ServicesTest
    {
        private readonly IServices<Article> _services;
        public ServicesTest(IServices<Article> services)
        {
            _services = services;
        }
        public ServicesTest() { }
        [TestMethod]
        public void GetAllDataList()
        {
            string searchStr = string.Empty;

            var dataReturned = _services.GetList(searchStr);

            Assert.AreEqual(10, dataReturned.Count);
        }
    }
}

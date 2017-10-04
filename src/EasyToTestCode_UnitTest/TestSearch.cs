using EasyToTestCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EasyToTestCode_UnitTest
{
    public class TestSearch
    {
        public BetterDBSearch ctx;

        [TestMethod]
        public void BadSearchKeyword()
        {
            string Keyword = "round";
            List<string> Words = { "round", "square", "cylindrical" };
            var searchRequest = new SearchRequest(Keyword, Words);
            ///... code
            var result = ctx.OKSearch(searchRequest);
            Assert.IsTrue(result.value > 0);
        }

        [TestMethod]
        public void BetterSearchKeyword()
        {
            string Keyword = "round";
            List<string> Words = { "round", "square", "cylindrical" };
            var searchRequest = new SearchRequest(Keyword, Words);
            var searchRequest = new SearchRequest();
            ///... code
            var result = ctx.OKSearch(searchRequest);
            Assert.IsTrue(result.length == 1 && result.value == Keyword);
        }
    }
}

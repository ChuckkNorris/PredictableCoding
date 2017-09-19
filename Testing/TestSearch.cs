namespace PredictableCoding.Testing
{
    public class TestSearch
    {
        public BetterDBSearch ctx;
        [TestMethod]
        public void BadSearchKeyword()
        {
            string Keyword = "round";
            List<string> Words = {"round", "square","cylindrical" };
            var searchRequest = new SearchRequest(Keyword, Words);
            //... code
            var result = ctx.OKSearch(searchRequest);
            Assert.isTrue(result.length > 0 );
        }
        [TestMethod]
        public void BetterSearchKeyword()
        {
            string Keyword = "round";
            List<string> Words = { "round", "square", "cylindrical" };
            var searchRequest = new SearchRequest(Keyword, Words);
            //... code
            var result = ctx.OKSearch(searchRequest);
            Assert.isTrue(result.length == 1 && result.value == Keyword);
        }

    }
}

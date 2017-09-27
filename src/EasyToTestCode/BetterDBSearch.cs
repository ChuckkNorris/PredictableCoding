namespace EasyToTestCode
{
    public class BetterDBSearch
    {
        //keyword = "round" ; fieldToSearch = {"square" "round" "cylindrical"}
        public Model OKSearch(SearchRequest request)
        {
            var result = request.search();
            return result;
        }
        public DBConnection Connect(string connStr) {
            var ctx = new DBConnection(connStr);
            return ctx;
        }

        public bool ValidateParameters(SearchRequest request)
        {
            return request.IsValid();
        }
    }
}

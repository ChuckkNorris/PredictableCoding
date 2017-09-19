namespace PredictableCoding.Testing
{
    public class BadDBSearch
    {
        //keyword = "round" ; fieldToSearch = {"square" "round" "cylindrical"}
        public Model BadSearch(string connString, string keyword, List<string> fieldToSearch)
        {
            var conn = new DBConnection(connString);
            conn.Connect();
            var result = conn.Search(keyword,fieldToSearch);
            return result;
        }
    }
}

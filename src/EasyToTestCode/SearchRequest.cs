namespace EasyToTestCode
{
    public class SearchRequest
    {
        public string keyword { get; set; }
        public string fieldToSearch { get; set; }
        public DBConnection ctx { get; set; }

        public Model search()
        {
            return ctx.Search();
        }

        public bool IsValid()
        {
            return false;
        }
    }
}

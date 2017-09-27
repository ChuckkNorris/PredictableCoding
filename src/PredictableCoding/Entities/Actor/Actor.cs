namespace PredictableCoding.Controllers.Entities
{
    public class Actor
    {
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value?.ToLower().Trim();
            }
        }
        public string LastName { get; set; }

    }
}
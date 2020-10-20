namespace Support_Your_Locals.Models
{
    public class SearchResponse
    {

        public string OwnersSurname { get; set; }
        public string Header { get; set; }
        public bool SearchInDescription { get; set; }
        public bool[] WeekdaySelected { get; set; } = new bool[7];
    }
}

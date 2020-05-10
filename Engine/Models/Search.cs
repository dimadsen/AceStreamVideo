namespace Engine.Models
{
    public class Search
    {
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public string InfoHash { get; set; }

        public string Name { get; set; }
    }
}

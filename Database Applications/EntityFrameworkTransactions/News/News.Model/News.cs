namespace News.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class News
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}

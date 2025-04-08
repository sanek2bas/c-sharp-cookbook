namespace Calling.Python.Code.From.C.Sharp
{
    public class Tweet
    {
        [Column("Screen Name")]
        public string ScreenName { get; set; }

        [Column("Date")]
        public DateTime CreatedAt { get; set; }

        [Column("Text")]
        public string Text { get; set; }

        [Column("Semantic Analysis")]
        public string Semantics { get; set; }
    }
}

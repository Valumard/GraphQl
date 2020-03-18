namespace GraphQlServer.Database.Schema
{
    public class SubmitPostInput
    {
        public string Header { get; set; }

        public string Content { get; set; }
        public string Author { get; internal set; }
    }
}

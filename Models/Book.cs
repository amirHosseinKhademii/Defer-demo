namespace Graph_Demo.Models
{
    public sealed record Book
    {
        public Guid Id { get; init; }
        public string Title { get; init; }

        public Author Author { get; init; }
    }

    public sealed record Author
    {
        public string Name { get; init; }
    }
}
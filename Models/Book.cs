namespace Graph_Demo.Models
{
    public record Book
    {
        public Guid Id { get; init; }
        public string Title { get; init; }

        public Author Author { get; init; }
    }

    public record Author
    {
        public string Name { get; init; }
    }
}
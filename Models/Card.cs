namespace Graph_Demo.Models
{
    public sealed record Card
    {
        public Guid Id { get; init; }

        public Header Header { get; init; }

        public Body Body { get; init; }

    }

    public sealed record Header
    {
        public string Title { get; init; }

        public int Followers { get; init; }

        public string Image { get; init; }


    }

    public sealed record Body
    {
        public string Description { get; init; }

        public List<Todo> Todos { get; init; }

    }

    public sealed record Todo
    {
        public Guid Id { get; init; }
        public string Title { get; init; }

        public string Description { get; init; }

        public bool Completed { get; init; }

    }


}
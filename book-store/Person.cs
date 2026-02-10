namespace book_store
{
    public abstract class Person : IPersonActions
    {
        public bool MarkForDelete { get; set; } = false;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Ensure parameters match your interface (decimal vs double)
        public abstract decimal ApplyDiscount(decimal price, ENMembershipType member);
    }
}
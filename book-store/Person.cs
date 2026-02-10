namespace book_store
{
    public class Person : IPersonActions
    {
        public bool MarkForDelete = false;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual decimal ApplyDiscount(decimal price, ENMembershipType meber)
        {
            return price;
        }
    }
}
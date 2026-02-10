namespace book_store
{
    public class Client : Person
    {
        public ENMembershipType EMembershipType { get; set; }
        public ENGenre FavBook { get; set; }

        public override decimal ApplyDiscount(decimal price, ENMembershipType member)
        {
            if (member == ENMembershipType.Student) return price * 0.8m;
            if (member == ENMembershipType.Senior) return price * 0.9m;
            return price;
        }
    }
}
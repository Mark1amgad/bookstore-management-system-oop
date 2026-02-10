namespace book_store
{
    public class Client : Person
    {
        public ENMembershipType EMembershipType { get; set; }
        public ENGenre FavBook { get; set; }

        public override double ApplyDiscount(double price)
        {
            // Logic based on your diagrams
            return EMembershipType == ENMembershipType.Student ? price * 0.8 : price;
        }

        public static string[] MEM() => new string[] { "Regular", "Student", "Senior" };
    }
}
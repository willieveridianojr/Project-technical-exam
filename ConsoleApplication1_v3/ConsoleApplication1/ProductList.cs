namespace Model
{
    public class SetPricing
    {
        public Product Apple = new Product("Apple", 1.25M, 3.0M, 3); //product A $1.25 each, $3 for 3
        public Product Banana = new Product("Banana", 4.25M); //product B $4.25 each
        public Product Carrot = new Product("Carrot", 1.0M, 5.0M, 6); //product C $1 each, $5 for 6
        public Product Dumpling = new Product("Dumpling", 0.75M); //product D $0.75 each
    }
}

namespace Model
{
    public class Product
    {
        public string productName { get; set; }
        public decimal itemPrice { get; set; }
        public decimal bulkPrice { get; set; }
        public int bulkQty { get; set; }


        //for single products
        public Product(string productName, decimal itemPrice)
        {
            this.productName = productName;
            this.itemPrice = itemPrice;

        }

        //for bulk products
        public Product(string productName, decimal itemPrice, decimal bulkPrice, int bulkQty)
        {
            this.productName = productName;
            this.itemPrice = itemPrice;
            this.bulkPrice = bulkPrice;
            this.bulkQty = bulkQty;
        }

    }

}

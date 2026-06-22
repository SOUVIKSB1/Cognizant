namespace SortingCustomerOrders
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }

        public Order(string orderId, string customerName, double totalPrice)
        {
            OrderId = orderId;
            CustomerName = customerName;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return $"ID: {OrderId} | Customer: {CustomerName} | Total Price: ${TotalPrice:F2}";
        }
    }
}

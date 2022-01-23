namespace BarManager.Models.Requests
{
    public class ClientRequest
    {
        public string Name { get; set; }

        public double MoneySpend { get; set; }
        public int Discount { get; set; }
    }
}
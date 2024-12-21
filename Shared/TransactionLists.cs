namespace Shared
{
    public class TransactionLists
    {
        public List<DateTime> Times { get; set; }
        public List<decimal> Amounts { get; set; }
        

    }
    public class TransactionCategoryLists
    {
       
        public List<List<int>> Counts { get; set; }
        public List<List<string>> Categories { get; set; }

    }
}

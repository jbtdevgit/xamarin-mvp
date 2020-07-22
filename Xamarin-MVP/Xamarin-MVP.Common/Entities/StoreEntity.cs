namespace Xamarin_MVP.Common.Entities
{
    public class StoreEntity
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public StoreType StoreType { get; set; }
    }

    public enum StoreType
    {
        Baking = 0,
        Tool = 1,
        Carpentry = 2,
        Restaurant = 3
    }
}

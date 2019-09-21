namespace ParseTheParcel.Common.Parcel
{
    public class ParcelType
    {
        public int MaxLength { get; set; }
        public int MaxBreadth { get; set; }
        public int MaxHeight { get; set; }
        public double Price{ get; set; }

        public ParcelType(int maxLength, int maxBreadth, int maxHeight, double price)
        {
            MaxLength = maxLength;
            MaxBreadth = maxBreadth;
            MaxHeight = maxHeight;
            Price = price;

        }
    }
}

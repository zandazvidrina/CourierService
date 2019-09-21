namespace ParseTheParcel.Data.Services
{
    public class ParcelConfiguration : IParcelConfiguration
    {
        private const int MaxWeight = 25; //ToDo: This should come from Database

        public int GetMaxWeight()
        {
            return MaxWeight;
        }
    }
}

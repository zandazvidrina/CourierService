using ParseTheParcel.Business.Models;

namespace ParseTheParcel.Business.Logic
{
    public interface IParcelCalculator
    {
        Parcel CalculatePrice(Parcel parcel);
        Parcel RotateParcelIfNeeded(Parcel parcel);
    }
}

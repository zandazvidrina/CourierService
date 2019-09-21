using ParseTheParcel.Business.Models;

namespace ParseTheParcel.Business.Logic
{
    public interface IParcelValidation
    {
        bool ValidateLength(Parcel parcel);
        bool ValidateHeight(Parcel parcel);
        bool ValidateBreadth(Parcel parcel);
        bool ValidateWeight(Parcel parcel);
        int MaxLength { get; set; }
        int MaxHeight { get; set; }
        int MaxBreadth { get; set; }
        int MaxWeight { get; set; }
    }
}

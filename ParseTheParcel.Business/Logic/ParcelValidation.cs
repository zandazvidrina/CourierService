using System.Collections.Generic;
using ParseTheParcel.Business.Models;
using ParseTheParcel.Common.Enums;
using ParseTheParcel.Common.Parcel;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Business.Logic
{
    public class ParcelValidation:IParcelValidation
    {
        public int MaxLength { get; set; }
        public int MaxHeight { get; set; }
        public int MaxBreadth { get; set; }
        public int MaxWeight { get; set; }
        
        private readonly IDictionary<ParcelSize, ParcelType> parcelTypeDictionary;

        public ParcelValidation(IParcelTypeDictionary parcelTypeDictionary, IParcelConfiguration parcelConfiguration)
        {
            this.parcelTypeDictionary = parcelTypeDictionary.GetAll();
            MaxLength = this.parcelTypeDictionary[ParcelSize.Large].MaxLength;
            MaxHeight = this.parcelTypeDictionary[ParcelSize.Large].MaxHeight;
            MaxBreadth = this.parcelTypeDictionary[ParcelSize.Large].MaxBreadth;
            MaxWeight = parcelConfiguration.GetMaxWeight();
        }

        public bool ValidateLength(Parcel parcel)
        {
            return parcel.Length > 0 && parcel.Length <= MaxLength;
        }

        public bool ValidateHeight(Parcel parcel)
        {
            return parcel.Height > 0 && parcel.Height <= MaxHeight;
        }

        public bool ValidateBreadth(Parcel parcel)
        {
            return parcel.Breadth > 0 && parcel.Breadth <= MaxBreadth;
        }

        public bool ValidateWeight(Parcel parcel)
        {
            return parcel.Weight > 0 && parcel.Weight <= MaxWeight;
        }
    }
}

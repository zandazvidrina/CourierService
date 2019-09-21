using System.Collections.Generic;
using System.Linq;
using ParseTheParcel.Business.Models;
using ParseTheParcel.Common.Enums;
using ParseTheParcel.Common.Parcel;
using ParseTheParcel.Data.Services;

namespace ParseTheParcel.Business.Logic
{
    public class ParcelCalculator : IParcelCalculator
    {
        private readonly IDictionary<ParcelSize, ParcelType> parcelTypeDictionary;

        public ParcelCalculator(IParcelTypeDictionary parcelTypeDictionary)
        {
            this.parcelTypeDictionary = parcelTypeDictionary.GetAll();
        }

        public Parcel CalculatePrice(Parcel parcel)
        {
            var calculatedParcel = parcel;
            foreach (var element in parcelTypeDictionary)
            {
                if (parcel.Length > element.Value.MaxLength || parcel.Breadth > element.Value.MaxBreadth ||
                    parcel.Height > element.Value.MaxHeight) continue;
                calculatedParcel.Size = element.Key;
                calculatedParcel.Price = element.Value.Price;
                break;
            }

            return calculatedParcel;
        }

        public Parcel RotateParcelIfNeeded(Parcel parcel)
        {
            var dimensionsList = new List<int> { parcel.Height, parcel.Length, parcel.Breadth };
            var rotatedParcel = parcel;

            if (parcel.Height <= parcel.Length && parcel.Length <= parcel.Breadth) return rotatedParcel;

            rotatedParcel.Height = dimensionsList.Min();
            dimensionsList.Remove(dimensionsList.Min());

            rotatedParcel.Length = dimensionsList.Min();
            dimensionsList.Remove(dimensionsList.Min());

            rotatedParcel.Breadth = dimensionsList.Min();
            dimensionsList.Remove(dimensionsList.Min());
            return rotatedParcel;
        }
    }
}


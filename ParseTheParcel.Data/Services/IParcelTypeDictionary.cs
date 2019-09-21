using System.Collections.Generic;
using ParseTheParcel.Common.Enums;
using ParseTheParcel.Common.Parcel;

namespace ParseTheParcel.Data.Services
{
    public interface IParcelTypeDictionary
    {
        IDictionary<ParcelSize, ParcelType> GetAll();
    }
}

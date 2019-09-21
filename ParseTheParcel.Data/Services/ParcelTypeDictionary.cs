using System.Collections.Generic;
using ParseTheParcel.Common.Enums;
using ParseTheParcel.Common.Parcel;

namespace ParseTheParcel.Data.Services
{
    public class ParcelTypeDictionary:IParcelTypeDictionary
    {
        readonly Dictionary<ParcelSize, ParcelType> dictionary;
        
            public ParcelTypeDictionary()                                          
            {
                dictionary = new Dictionary<ParcelSize, ParcelType> //TODO these should come from database
                {
                    {ParcelSize.Small, new ParcelType(200, 300, 150, 5)},
                    {ParcelSize.Medium, new ParcelType(300, 400, 200, 7.5)},
                    {ParcelSize.Large, new ParcelType(400, 600, 250, 8.5)}
                };

            }

            public IDictionary<ParcelSize, ParcelType> GetAll()
            {
                return dictionary;
            }

        }
    
}

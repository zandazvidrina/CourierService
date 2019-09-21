using System.ComponentModel.DataAnnotations;
using ParseTheParcel.Common.Enums;

namespace ParseTheParcel.Business.Models
{
    public class Parcel
    {

        [Required]  
        public int Length { get; set; }

        [Required]
        public int Breadth { get; set; }

        [Required]
        public int Height{ get; set; }

        [Required]
        public double Weight { get; set; }

        public double Price { get; set; }

        public ParcelSize Size { get; set; }

    }

}

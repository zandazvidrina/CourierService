using ParseTheParcel.Business.Logic;
using ParseTheParcel.Business.Models;
using System.Web.Mvc;

namespace ParseTheParcel.Web.Controllers
{
    public class ParcelController : Controller
    {
        static Parcel parcel = new Parcel();
        private readonly IParcelCalculator parcelCalculator;
        private readonly IParcelValidation parcelValidation;

        public ParcelController(IParcelCalculator parcelCalculator, IParcelValidation parcelValidation)
        {
            this.parcelCalculator = parcelCalculator;
            this.parcelValidation = parcelValidation;
        }
        
        [HttpGet]
        public ActionResult ParcelInputData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParcelInputData(Parcel parcel)
        {
            parcel = parcelCalculator.RotateParcelIfNeeded(parcel);
            

            if (!parcelValidation.ValidateLength(parcel))
            {
                ModelState.AddModelError(nameof(parcel.Length), $"The length must be between 1 and {parcelValidation.MaxLength} mm");
            }

            if (!parcelValidation.ValidateBreadth(parcel))
            {
                ModelState.AddModelError(nameof(parcel.Breadth), $"The breadth must be between 1 and {parcelValidation.MaxBreadth} mm");
            }

            if (!parcelValidation.ValidateHeight(parcel))
            {
                ModelState.AddModelError(nameof(parcel.Height), $"The height must be between 1 and {parcelValidation.MaxHeight} mm");
            }

            if (!parcelValidation.ValidateWeight(parcel))
            {
                ModelState.AddModelError(nameof(parcel.Weight), $"The weight  must be between 1 and {parcelValidation.MaxWeight} kg");
            }

            if (ModelState.IsValid)
            {
                
                parcel = parcelCalculator.CalculatePrice(parcel);
                return RedirectToAction("ParcelData", "Parcel", parcel);
            }

            return View();
        }

        public ActionResult ParcelData(Parcel parcel)
        {
            return View(parcel);
        }

    }
}
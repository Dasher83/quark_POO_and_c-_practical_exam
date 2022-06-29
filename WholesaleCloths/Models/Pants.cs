using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Models
{
    internal class Pants : Garment
    {
        private const double SlimFitMultiplier = 0.88;

        private PantsTypeEnum pantsType;
        
        public Pants(
            GarmentQualityEnum quality,
            decimal unitPrice,
            uint quantityInStock,
            PantsTypeEnum pantsType) : base(quality, unitPrice, quantityInStock)
        {
            if (!Enum.IsDefined(typeof(PantsTypeEnum), pantsType))
            {
                throw new ArgumentOutOfRangeException(nameof(pantsType), $"Undefined pants type value: {pantsType}");
            }
            this.pantsType = pantsType;
        }

        public PantsTypeEnum PantsType { get { return pantsType; } }

        public override decimal Quote(decimal baseQuote)
        {
            decimal price = baseQuote;
            if (pantsType == PantsTypeEnum.SlimFit)
            {
                price *= (decimal)SlimFitMultiplier;
            }
            price = base.Quote(baseQuote: price);
            return price;
        }
    }
}

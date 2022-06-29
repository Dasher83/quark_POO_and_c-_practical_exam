using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Models
{
    internal class Shirt : Garment
    {
        private const double ShortSleeveMultiplier = 0.9;
        private const double MaoNeckMultiplier = 1.03;

        private SleeveTypeEnum sleeveType;
        private NeckTypeEnum neckType;

        public Shirt(GarmentQualityEnum quality, decimal unitPrice, uint quantityInStock, SleeveTypeEnum sleeveType, NeckTypeEnum neckType) : base(quality, unitPrice, quantityInStock)
        {
            if (!Enum.IsDefined(typeof(SleeveTypeEnum), sleeveType))
            {
                throw new ArgumentOutOfRangeException(nameof(sleeveType), $"Undefined sleeve type value: {sleeveType}");
            }
            if (!Enum.IsDefined(typeof(NeckTypeEnum), neckType))
            {
                throw new ArgumentOutOfRangeException(nameof(neckType), $"Undefined neck type value: {neckType}");
            }
            this.sleeveType = sleeveType;
            this.neckType = neckType;
        }

        public SleeveTypeEnum SleeveType { get => sleeveType; }

        public NeckTypeEnum NeckType { get => neckType; }

        public override decimal Quote(decimal baseQuote)
        {
            decimal price = baseQuote;
            if (sleeveType == SleeveTypeEnum.Short)
            {
                price *= (decimal)ShortSleeveMultiplier;
            }
            if (neckType == NeckTypeEnum.Mao)
            {
                price *= (decimal)MaoNeckMultiplier;
            }
            price = base.Quote(baseQuote: price);
            return price;
        }
    }
}

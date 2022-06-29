using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Models
{
    internal abstract class Garment
    {
        private const double PremiumQualityMultiplier = 1.3;

        protected string id;
        protected GarmentQualityEnum quality;
        protected decimal unitPrice;
        private uint quantityInStock;

        public Garment(GarmentQualityEnum quality, decimal unitPrice, uint quantityInStock)
        {
            if (!Enum.IsDefined(typeof(GarmentQualityEnum), quality))
            {
                throw new ArgumentOutOfRangeException(nameof(quality), $"Undefined garment quality value: {quality}");
            }
            Guid uuid = Guid.NewGuid();
            id = uuid.ToString();
            this.quality = quality;
            this.unitPrice = unitPrice;
            this.quantityInStock = quantityInStock;
        }

        public string Id { get => id; }

        public GarmentQualityEnum Quality { get => quality; }

        public uint QuantityInStock { get => quantityInStock; }

        public virtual decimal Quote(decimal baseQuote)
        {
            decimal price = baseQuote;
            if (quality == GarmentQualityEnum.Premium)
            {
                price *= (decimal)PremiumQualityMultiplier;
            }
            return price;
        }
    }
}

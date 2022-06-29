using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Shared.DTOs
{
    internal class GarmentDTO: DTO
    {
        public GarmentQualityEnum? garmentQuality;
        public GarmentTypeEnum? garmentType;
        public SleeveTypeEnum? sleeveType;
        public NeckTypeEnum? neckType;
        public PantsTypeEnum? pantsType;
        public decimal? garmentUnitPrice;
        public uint? garmentQuantity;

        public GarmentDTO(
            GarmentQualityEnum? garmentQuality = null,
            GarmentTypeEnum? garmentType = null,
            SleeveTypeEnum? sleeveType = null,
            NeckTypeEnum? neckType = null,
            PantsTypeEnum? pantsType = null,
            decimal? garmentUnitPrice = null,
            uint? garmentQuantity = null)
        {
            this.garmentQuality = garmentQuality;
            this.garmentType = garmentType;
            this.sleeveType = sleeveType;
            this.neckType = neckType;
            this.pantsType = pantsType;
            this.garmentUnitPrice = garmentUnitPrice;
            this.garmentQuantity = garmentQuantity;
        }
    }
}

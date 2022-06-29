using WholesaleCloths.Shared.DTOs;

namespace WholesaleCloths.Shared.Interfaces
{
    internal interface IClothingStoreController
    {
        public uint CheckStock(GarmentDTO garmentDTO);

        public QuotationDTO? QuoteGarment(GarmentDTO garmentDTO);

        public List<QuotationDTO> GetCurrentWholesalerQuotationHistory();
        public WholesalerDTO WholesalerDTO { get; }
        public ClothingStoreDTO ClothingStoreDTO { get; }
    }
}

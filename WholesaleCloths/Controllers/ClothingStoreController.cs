using WholesaleCloths.Models;
using WholesaleCloths.Shared.Interfaces;
using WholesaleCloths.Shared.DTOs;
using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Controllers
{
    internal class ClothingStoreController: IClothingStoreController
    {
        private Wholesaler wholesaler;
        private ClothingStore clothingStore;

        public WholesalerDTO WholesalerDTO { get{ return (WholesalerDTO)this.wholesaler.GetDTO(); } }

        public ClothingStoreDTO ClothingStoreDTO { get{ return (ClothingStoreDTO)this.clothingStore.GetDTO(); } }
        public ClothingStoreController(ref Wholesaler wholesaler)
        {
            this.wholesaler = wholesaler;
            this.clothingStore = wholesaler.ClothingStore;
        }

        private Garment? SearchForGarment(GarmentDTO garmentDTO)
        {
            foreach (Garment garment in clothingStore.Garments)
            {
                if (garment.Quality != garmentDTO.garmentQuality)
                {
                    continue;
                }

                switch (garmentDTO.garmentType)
                {
                    case GarmentTypeEnum.Shirt:
                        if (garment.GetType() != typeof(Shirt))
                        {
                            continue;
                        }
                        Shirt shirt = (Shirt)garment;
                        if (shirt.SleeveType != garmentDTO.sleeveType)
                        {
                            continue;
                        }
                        if (shirt.NeckType != garmentDTO.neckType)
                        {
                            continue;
                        }
                        return garment;
                        break;
                    case GarmentTypeEnum.Pants:
                        if (garment.GetType() != typeof(Pants))
                        {
                            continue;
                        }
                        Pants pants = (Pants)garment;
                        if (pants.PantsType != garmentDTO.pantsType)
                        {
                            continue;
                        }
                        return pants;
                        break;
                }
            }
            return null;
        }
        public uint CheckStock(GarmentDTO garmentDTO)
        {
            Garment? garment = SearchForGarment(garmentDTO: garmentDTO);
            uint quantityInStock = garment != null ? garment.QuantityInStock : 0;
            return quantityInStock;
        }

        public QuotationDTO? QuoteGarment(GarmentDTO garmentDTO)
        {
            QuotationDTO? quotationDTO = null;
            Garment? garment = SearchForGarment(garmentDTO: garmentDTO);
            if (garment != null &&
                garmentDTO.garmentQuantity != null &&
                garmentDTO.garmentUnitPrice != null)
            {
                IModel quote = this.wholesaler.Quote(
                    garment: garment, 
                    garmentUnitsQuoted: (uint)garmentDTO.garmentQuantity,
                    garmentUnitPriceQuoted: (decimal)garmentDTO.garmentUnitPrice);
                return (QuotationDTO?)quote.GetDTO();
            }
            
            return quotationDTO;
        }

        public List<QuotationDTO> GetCurrentWholesalerQuotationHistory()
        {
            List<QuotationDTO> quotationHistory = new List<QuotationDTO>();
            foreach(IModel quotation in this.wholesaler.Quotes)
            {
                QuotationDTO quotationDTO = (QuotationDTO)quotation.GetDTO();
                quotationHistory.Add(quotationDTO);
            }
            return quotationHistory;
        }
    }
}

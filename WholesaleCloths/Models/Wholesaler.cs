using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Models
{
    internal class Wholesaler: IModel
    {
        private string id;
        private string firstName;
        private string lastName;
        private List<Quotation> quotes;
        private ClothingStore clothingStore;

        public Wholesaler(string firstName, string lastName, ref ClothingStore clothingStore)
        {
            Guid uuid = Guid.NewGuid();
            id = uuid.ToString();
            this.firstName = firstName;
            this.lastName = lastName;
            quotes = new List<Quotation>();
            this.clothingStore = clothingStore;
        }
        
        public List<Quotation> Quotes { get { return quotes; } }

        public ClothingStore ClothingStore { get { return clothingStore; } }

        public Quotation Quote(Garment garment, uint garmentUnitsQuoted, decimal garmentUnitPriceQuoted)
        {
            decimal unitQuote = garment.Quote(garmentUnitPriceQuoted);
            decimal totalGarmentsQuote = unitQuote * garmentUnitsQuoted;

            Quotation quotation = new Quotation(
                garment: garment,
                garmentUnitsQuoted: garmentUnitsQuoted, 
                quotedPrice: totalGarmentsQuote);

            quotes.Add(quotation);
            return quotation;
        }

        public DTO GetDTO()
        {
            DTO dto = new WholesalerDTO(id: this.id, firstName: this.firstName, lastName: this.lastName);
            return dto;
        }
    }
}

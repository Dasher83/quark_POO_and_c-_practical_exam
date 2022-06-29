using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Models
{
    internal class Quotation: IModel
    {
        private string id;
        private DateTime createdAt;
        private Garment garment;
        private uint garmentUnitsQuoted;
        private decimal quotedPrice;

        public Quotation(Garment garment, uint garmentUnitsQuoted, decimal quotedPrice)
        {
            Guid uuid = Guid.NewGuid();
            id = uuid.ToString();
            createdAt = DateTime.UtcNow;
            this.garment = garment;
            this.garmentUnitsQuoted = garmentUnitsQuoted;
            this.quotedPrice = quotedPrice;
        }

        public uint GarmentUnitsQuoted { get { return GarmentUnitsQuoted; } }

        public DTO GetDTO()
        {
            DTO dto = new QuotationDTO(
                id: this.id,
                createdAt: this.createdAt,
                garmentId: this.garment.Id,
                garmentUnitsQuoted: this.garmentUnitsQuoted,
                quotedPrice: this.quotedPrice);
            return dto;
        }
    }
}

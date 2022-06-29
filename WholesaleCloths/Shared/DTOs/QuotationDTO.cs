namespace WholesaleCloths.Shared.DTOs
{
    internal class QuotationDTO: DTO
    {
        public string id;
        public DateTime createdAt;
        public string garmentId;
        public uint garmentUnitsQuoted;
        public decimal quotedPrice;

        public QuotationDTO(
            string id,
            DateTime createdAt,
            string garmentId,
            uint garmentUnitsQuoted,
            decimal quotedPrice)
        {
            this.id = id;
            this.createdAt = createdAt;
            this.garmentId = garmentId;
            this.garmentUnitsQuoted = garmentUnitsQuoted;
            this.quotedPrice = quotedPrice;
        }
    }
}

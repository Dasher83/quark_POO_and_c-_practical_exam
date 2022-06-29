using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Models
{
    internal class ClothingStore: IModel
    {
        private string id;
        private string name;
        private string address;
        private List<Garment> garments;
        private List<Wholesaler> wholesalers;

        public ClothingStore(string name, string address)
        {
            Guid uuid = Guid.NewGuid();
            id = uuid.ToString();
            this.name = name;
            this.address = address;
            garments = new List<Garment>();
            wholesalers = new List<Wholesaler>();
        }

        public List<Garment> Garments { get => garments; }

        public void AddGarments(List<Garment> garments)
        {
            this.garments.AddRange(garments);
        }

        public DTO GetDTO()
        {
            DTO dto = new ClothingStoreDTO(name: this.name, address: this.address);
            return dto;
        }
    }
}

namespace WholesaleCloths.Shared.DTOs
{
    internal class ClothingStoreDTO: DTO
    {
        public string name;
        public string address;

        public ClothingStoreDTO(string name, string address)
        {
            this.name = name;
            this.address = address;
        }
    }
}

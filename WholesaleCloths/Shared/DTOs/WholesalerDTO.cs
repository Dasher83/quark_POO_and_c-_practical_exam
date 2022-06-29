namespace WholesaleCloths.Shared.DTOs
{
    internal class WholesalerDTO: DTO
    {
        public string id;
        public string firstName;
        public string lastName;

        public WholesalerDTO(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Views.WholesalerViews
{
    internal class HeaderView
    {
        private IClothingStoreController clothingStoreController;

        public HeaderView(IClothingStoreController clothingStoreController)
        {
            this.clothingStoreController = clothingStoreController;
        }

        public void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WholesalerDTO wholesalerDTO = this.clothingStoreController.WholesalerDTO;
            ClothingStoreDTO clothingStoreDTO = this.clothingStoreController.ClothingStoreDTO;
            Console.WriteLine("Cotizador Express");
            Console.WriteLine();
            Console.WriteLine($"Comercio: {clothingStoreDTO.name}");
            Console.WriteLine($"Ubicación: {clothingStoreDTO.address}");
            Console.WriteLine();
            Console.WriteLine($"Vendedor: {wholesalerDTO.firstName,-2} {wholesalerDTO.lastName,-2} | ID: {wholesalerDTO.id,-1}");
            Console.ResetColor();
        }
    }
}

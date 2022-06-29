using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Views.WholesalerViews
{
    internal class MainMenuView
    {
        private IClothingStoreController clothingStoreController;

        public MainMenuView(IClothingStoreController clothingStoreController)
        {
            this.clothingStoreController = clothingStoreController;
        }

        public void Show()
        {
            Console.Clear();
            new HeaderView(this.clothingStoreController).ShowHeader();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingresar una opción:");
            Console.WriteLine("1- Cotizar");
            Console.WriteLine("2- Historial de cotizaciones");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3- Salir del programa");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}

using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;

namespace WholesaleCloths.Views.WholesalerViews
{
    internal class QuoteHistoryView
    {
        private IClothingStoreController clothingStoreController;

        public QuoteHistoryView(IClothingStoreController clothingStoreController)
        {
            this.clothingStoreController = clothingStoreController;
        }
        public void ShowResult()
        {
            List<QuotationDTO> quotationHistory = this.clothingStoreController.GetCurrentWholesalerQuotationHistory();

            Console.Clear();
            new HeaderView(this.clothingStoreController).ShowHeader();
            Console.WriteLine();
            Console.WriteLine();
            
            if (quotationHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Historial de cotizaciones:");
                Console.WriteLine();
                Console.WriteLine("No hay cotizaciones que mostrar ...");
                Console.WriteLine("Vuelva a consultar este historial en otro momento.");
                Console.WriteLine("Dale, cotiza algo, anda a trabajar che!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Historial de cotizaciones:");
            }
            uint index = (uint)quotationHistory.Count;
            quotationHistory.Reverse();
            foreach (QuotationDTO quotationDTO in quotationHistory)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                Console.WriteLine($"#{index}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"ID de cotización: {quotationDTO.id}");
                Console.WriteLine($"Momento de cotización: {quotationDTO.createdAt}");
                Console.WriteLine($"ID de prenda cotizada: {quotationDTO.garmentId}");
                Console.WriteLine($"Cantidad de unidades cotizadas: {quotationDTO.garmentUnitsQuoted}");
                Console.WriteLine($"Precio total cotizado: {quotationDTO.quotedPrice:0.00}");
                index--;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}

using WholesaleCloths.Shared.DTOs;
using WholesaleCloths.Shared.Interfaces;
using WholesaleCloths.Utils;
using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Views.WholesalerViews
{
    internal class QuoteMenuView
    {
        private GarmentDTO garmentDTO;
        private IClothingStoreController clothingStoreController;

        public QuoteMenuView(IClothingStoreController clothingStoreController)
        {
            this.clothingStoreController = clothingStoreController;
            this.garmentDTO = new GarmentDTO();
        }
        public void ShowIntro()
        {
            Console.Clear();
            new HeaderView(this.clothingStoreController).ShowHeader();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Realizar Cotización");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public void LoadData()
        {
            Console.WriteLine("Seleccione el tipo de prenda a cotizar:");
            Console.WriteLine("1- Camisa");
            Console.WriteLine("2- Pantalón");

            garmentDTO.garmentType = (GarmentTypeEnum?)UserInputTaker.TakeByteBasedEnumInput(
                inputSelectedMessages: new string[] {
                    "Has seleccionado 'Camisa'",
                    "Has seleccionado 'Pantalón'"},
                outputValues: new byte[] {
                    (byte)GarmentTypeEnum.Shirt,
                    (byte)GarmentTypeEnum.Pants});

            Console.WriteLine();

            switch (garmentDTO.garmentType)
            {
                case GarmentTypeEnum.Shirt:
                    Console.WriteLine("Seleccione el tipo de manga:");
                    Console.WriteLine("1- Manga corta");
                    Console.WriteLine("2- Manga larga");

                    garmentDTO.sleeveType = (SleeveTypeEnum?)UserInputTaker.TakeByteBasedEnumInput(
                        inputSelectedMessages: new string[] {
                            "Has seleccionado 'Manga corta'",
                            "Has seleccionado 'Manga larga'"},
                        outputValues: new byte[] {
                            (byte)SleeveTypeEnum.Short,
                            (byte)SleeveTypeEnum.Long});

                    Console.WriteLine();
                    Console.WriteLine("Seleccione el tipo de cuello:");
                    Console.WriteLine("1- Cuello común");
                    Console.WriteLine("2- Cuello mao");

                    garmentDTO.neckType = (NeckTypeEnum?)UserInputTaker.TakeByteBasedEnumInput(
                        inputSelectedMessages: new string[] {
                            "Has seleccionado 'Cuello común'",
                            "Has seleccionado 'Cuello mao'"},
                        outputValues: new byte[] {
                            (byte)NeckTypeEnum.Standard,
                            (byte)NeckTypeEnum.Mao});

                    break;
                case GarmentTypeEnum.Pants:
                    Console.WriteLine("Seleccione el tipo de pantalón:");
                    Console.WriteLine("1- Común");
                    Console.WriteLine("2- Chupín");

                    garmentDTO.pantsType = (PantsTypeEnum?)UserInputTaker.TakeByteBasedEnumInput(
                        inputSelectedMessages: new string[] {
                            "Has seleccionado pantalón 'Común'",
                            "Has seleccionado pantalón 'Chupín'"},
                        outputValues: new byte[] {
                            (byte)PantsTypeEnum.Standard,
                            (byte)PantsTypeEnum.SlimFit});
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Seleccione la calidad de la prenda:");
            Console.WriteLine("1- Standard");
            Console.WriteLine("2- Premium");

            garmentDTO.garmentQuality = (GarmentQualityEnum?)UserInputTaker.TakeByteBasedEnumInput(
                inputSelectedMessages: new string[] {
                    "Has seleccionado pantalón 'Standard'",
                    "Has seleccionado pantalón 'Premium'"},
                outputValues: new byte[] {
                    (byte)GarmentQualityEnum.Standard,
                    (byte)GarmentQualityEnum.Premium});

            uint unitsInStock = this.clothingStoreController.CheckStock(garmentDTO: garmentDTO);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hay {unitsInStock} unidades en stock del tipo de prenda descripto.");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine();
            Console.WriteLine("Ingrese precio por unidad: ");
            garmentDTO.garmentUnitPrice = UserInputTaker.TakeDecimalInput(min:0);

            Console.WriteLine();
            Console.WriteLine("Ingrese cantidad de prendas a cotizar: ");
            uint garmentQuantityInStock = this.clothingStoreController.CheckStock(garmentDTO);
            garmentDTO.garmentQuantity = (uint)UserInputTaker.TakeIntInput(min:1, max:(int?)garmentQuantityInStock);
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Datos cargados exitosamente");
            Console.WriteLine("Procesando ...");
            Console.WriteLine($"Agregando los extras correspondientes ...");
        }

        public void ShowResult()
        {
            Console.WriteLine();
            QuotationDTO? quotationDTO = this.clothingStoreController.QuoteGarment(this.garmentDTO);
            if (quotationDTO != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"La cotización de las {quotationDTO.garmentUnitsQuoted} prendas es de {quotationDTO.quotedPrice:0.00} Zeni");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al cotizar. Intentelo de nuevo...");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}

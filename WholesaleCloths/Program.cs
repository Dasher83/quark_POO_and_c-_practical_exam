using WholesaleCloths.Controllers;
using WholesaleCloths.Models;
using WholesaleCloths.Shared.Interfaces;
using WholesaleCloths.Testing;
using WholesaleCloths.Views.WholesalerViews;

bool exit = false;

ClothingStore clothingStore = TestDataLoader.LoadClothingStore();
Wholesaler wholesaler = TestDataLoader.LoadWholesaler(clothingStore: ref clothingStore);
clothingStore.AddGarments(TestDataLoader.LoadShirts());
clothingStore.AddGarments(TestDataLoader.LoadPants());
IClothingStoreController clothingStoreController = new ClothingStoreController(ref wholesaler); 

do
{
    new MainMenuView(clothingStoreController).Show();
    Console.ForegroundColor = ConsoleColor.Blue;
    string? userInput = Console.ReadLine();
    userInput = userInput != null ? userInput.Trim() : userInput;
    Console.ResetColor();
    switch (userInput)
    {
        case "1":
            QuoteMenuView quoteMenuView = new QuoteMenuView(clothingStoreController);
            quoteMenuView.ShowIntro();
            quoteMenuView.LoadData();
            quoteMenuView.ShowResult();
            break;
        case "2":
            QuoteHistoryView quoteHistoryView = new QuoteHistoryView(clothingStoreController);
            quoteHistoryView.ShowResult();
            break;
        case "3":
            exit = true;
            break;
        default:
            Console.Clear();
            new HeaderView(clothingStoreController).ShowHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Opción inválida !");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
            break;
    }
} while (!exit);

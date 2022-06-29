using WholesaleCloths.Models;
using static WholesaleCloths.Shared.Enums;

namespace WholesaleCloths.Testing
{
    internal class TestDataLoader
    {
        public static ClothingStore LoadClothingStore(
            string name = "Tienda de ropa del bástago verde", string address="El templo sagrado de Kami")
        {
            ClothingStore clothingStore = new ClothingStore(name: name, address: address);
            return clothingStore;
        }

        public static Wholesaler LoadWholesaler(
            ref ClothingStore clothingStore, string firstName="Piccolo", string lastName="Jr")
        {
            Wholesaler wholesaler = new Wholesaler(
                firstName: firstName, 
                lastName: lastName, 
                clothingStore: ref clothingStore);
            return wholesaler;
        }

        public static List<Garment> LoadShirts()
        {
            Random random = new Random();
            int max = 1000;
            List<Garment> shirts = new List<Garment>();
            Shirt shirt = new Shirt(
                    quality: GarmentQualityEnum.Standard,
                    unitPrice: (decimal)random.Next(1, max),
                    quantityInStock: 100,
                    sleeveType: SleeveTypeEnum.Short,
                    neckType: NeckTypeEnum.Mao
                    );

            shirts.Add(shirt);
            
            shirt = new Shirt(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 100,
                sleeveType: SleeveTypeEnum.Short,
                neckType: NeckTypeEnum.Mao
                );

            shirts.Add(shirt);
            
            shirt = new Shirt(
                quality: GarmentQualityEnum.Standard,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 150,
                sleeveType: SleeveTypeEnum.Short,
                neckType: NeckTypeEnum.Standard
                );

            shirts.Add(shirt);

            shirt = new Shirt(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 150,
                sleeveType: SleeveTypeEnum.Short,
                neckType: NeckTypeEnum.Standard
                );

            shirts.Add(shirt);

            shirt = new Shirt(
                quality: GarmentQualityEnum.Standard,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 75,
                sleeveType: SleeveTypeEnum.Long,
                neckType: NeckTypeEnum.Mao
                );

            shirts.Add(shirt);

            shirt = new Shirt(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 75,
                sleeveType: SleeveTypeEnum.Long,
                neckType: NeckTypeEnum.Mao
                );

            shirts.Add(shirt);

            shirt = new Shirt(
                quality: GarmentQualityEnum.Standard,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 175,
                sleeveType: SleeveTypeEnum.Long,
                neckType: NeckTypeEnum.Standard
                );

            shirts.Add(shirt);

            shirt = new Shirt(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 175,
                sleeveType: SleeveTypeEnum.Long,
                neckType: NeckTypeEnum.Standard
                );

            shirts.Add(shirt);
            return shirts;
        }

        public static List<Garment> LoadPants()
        {
            Random random = new Random();
            int max = 1000;
            List<Garment> pantsList = new List<Garment>();

            Pants pants = new Pants(
                quality: GarmentQualityEnum.Standard,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 750, 
                pantsType: PantsTypeEnum.SlimFit);

            pantsList.Add(pants);

            pants = new Pants(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 750,
                pantsType: PantsTypeEnum.SlimFit);

            pantsList.Add(pants);

            pants = new Pants(
                quality: GarmentQualityEnum.Standard,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 250,
                pantsType: PantsTypeEnum.Standard);

            pantsList.Add(pants);

            pants = new Pants(
                quality: GarmentQualityEnum.Premium,
                unitPrice: (decimal)random.Next(1, max),
                quantityInStock: 250,
                pantsType: PantsTypeEnum.Standard);

            pantsList.Add(pants);

            return pantsList;
        }
    }
}

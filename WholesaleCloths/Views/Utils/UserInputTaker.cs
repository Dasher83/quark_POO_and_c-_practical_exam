namespace WholesaleCloths.Utils
{
    internal static class UserInputTaker
    {

        public static string TakeStringInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string? userInput = Console.ReadLine();
            string correctInput = userInput != null ? userInput.Trim() : "";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return correctInput;
        }

        public static int TakeIntInput(int? min = null, int? max = null)
        {
            int? correctInput = null;

            while (correctInput == null)
            {
                string userInput = TakeStringInput();
                try
                {
                    correctInput = int.Parse(userInput);
                    if(min != null)
                    {
                        if(correctInput < min)
                        {
                            throw new ArgumentOutOfRangeException("", $"El mínimo aceptable es: {min}"); ;
                        }

                        if (correctInput > max)
                        {
                            throw new ArgumentOutOfRangeException("", $"El máximo aceptable es: {max}");
                        }
                    }
                } 
                catch(FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Número entero inválido: {userInput}");
                    Console.WriteLine("Inténtelo de nuevo ...");
                    correctInput = null;
                    continue;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Inténtelo de nuevo ...");
                    correctInput = null;
                    continue;
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
            }

            return (int)correctInput;
        }

        private static void CheckParallelArrayParams(params Array[] listOfArrays)
        {
            if(listOfArrays.Length < 2)
            {
                throw new ArgumentException("Can't have parallel arrays with less than two arrays");
            }

            for(int index = 0; index < listOfArrays.Length-1; index++)
            {
                if(listOfArrays[index].Length != listOfArrays[index + 1].Length)
                {
                    throw new ArgumentException("Parallel arrrays should always have the same length");
                }
            }

            if (listOfArrays[0].Length < 1)
            {
                throw new ArgumentException("No elements in parallel arrays");
            }
        }

        public static byte TakeByteBasedEnumInput(string[] inputSelectedMessages, byte[] outputValues) 
        {
            CheckParallelArrayParams(inputSelectedMessages, outputValues);
            int userInput = 0;

            do
            {
                userInput = TakeIntInput();
                if (userInput < 1 || userInput > outputValues.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Opción inválida: {userInput}");
                    Console.WriteLine("Intentelo de nuevo...");
                }
            } while (userInput < 1 || userInput > outputValues.Length);

            byte correctInput = outputValues[userInput-1];
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(inputSelectedMessages[userInput-1]);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return correctInput;
        }

        public static decimal TakeDecimalInput(double? min = null)
        {
            double? intermediateInput = null;

            while (intermediateInput == null)
            {
                string userInput = TakeStringInput();
                try
                {
                    intermediateInput = double.Parse(userInput);
                    if (min != null)
                    {
                        if (intermediateInput < min)
                        {
                            throw new ArgumentOutOfRangeException("", $"El mínimo aceptable es: {min}"); ;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Número decimal inválido: {userInput}");
                    Console.WriteLine("Inténtelo de nuevo ...");
                    continue;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Inténtelo de nuevo ...");
                    intermediateInput = null;
                    continue;
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
            }

            decimal correctInput = (decimal)intermediateInput;
            return correctInput;
        }
    }
}

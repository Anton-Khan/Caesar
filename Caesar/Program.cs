using System;
using System.Linq;


namespace Caesar
{
    class Program
    {
        static readonly string _sourceAddress = "https://ilibrary.ru/text/11/p.71/index.html";
        static readonly string _textPathOriginal = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\Original.txt";
        static readonly string _textPathEncoded = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\Encoded.txt";
        static readonly string _textPathDecoded = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\Decoded.txt";
        static readonly string _textFullBook = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\FullBook.txt";
        static readonly string _tablePathOriginal = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\TableOriginal.txt";
        static readonly string _tablePathEncoded = @"C:\Users\Khan\source\repos\mirea\Caesar\Caesar\data\TableEncoded.txt";


        static void Main(string[] args)
        {
            new Alphabet();

            Parser parser = new Parser();
            //var fullText = parser.ParseFullBook(_sourceAddress.Replace("71", "<HERE>"), 1, 361);
            var sourceText = parser.ParseHtml(_sourceAddress);
            
            

            Cryptographer encoder = new Cryptographer(2);
            ShowMessage("Example Text");
            Console.WriteLine("\n"+sourceText);
            var encodedText = encoder.Encode(sourceText);
            ShowMessage("Encoded Text");
            Console.WriteLine("\n" + encodedText);
            

            FileManager fileManager = new FileManager();
            fileManager.SaveFile(_textPathOriginal, sourceText);
            fileManager.SaveFile(_textPathEncoded, encodedText);

            //fileManager.SaveFile(_textFullBook, fullText);
            var fullText = fileManager.LoadFile(_textFullBook);

            FrequencyTable frequencyTable = new FrequencyTable();
            var sourceTable = frequencyTable.CreateTableByText(fullText);
            var encodedTable = frequencyTable.CreateTableByText(encodedText);

            ShowMessage("Frequency Tables\n");
            

            Console.WriteLine("\n" + frequencyTable.ConvertTableToString(sourceTable));
            Console.WriteLine("\n" + frequencyTable.ConvertTableToString(encodedTable));

            ShowMessage("Sorted Result\n");
            

            var sourceList = frequencyTable.ConvertToSortedByFrequencyList(sourceTable);
            var encodedList = frequencyTable.ConvertToSortedByFrequencyList(encodedTable);

            fileManager.SaveFile(_tablePathOriginal, frequencyTable.ConvertListToString(sourceList));
            fileManager.SaveFile(_tablePathEncoded, frequencyTable.ConvertListToString(encodedList));

            Console.WriteLine("\n" + frequencyTable.ConvertListToString(sourceList));
            Console.WriteLine("\n" + frequencyTable.ConvertListToString(encodedList));


            ShowMessage("Step Distribution\n");

            Console.WriteLine(Cryptographer.CalculateStep(sourceList, encodedList));

            Console.WriteLine("Enter supposed step>");
            var input_step = Console.ReadLine();
            int step = 0;
            try
            {
                step = Int32.Parse(input_step);
                Cryptographer decoder = new Cryptographer(step);
                var decodedText = decoder.Decode(encodedText);
                ShowMessage("Decoded Text\n");
                Console.WriteLine(decodedText);
                fileManager.SaveFile(_textPathDecoded, decodedText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, cant parse your input!\n" + e.Message);
            }
            
            Console.Read();
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine("\n______________________________________________________");
            Console.WriteLine(message);
        }

        
    }
}

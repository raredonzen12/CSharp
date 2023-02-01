using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ReadAndPrintData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name (including the extension):");
            string fileName = Console.ReadLine();

            if (fileName.EndsWith(".json"))
            {
                ReadAndPrintJSONFile(fileName);
            }
            else if (fileName.EndsWith(".xml"))
            {
                ReadAndPrintXMLFile(fileName);
            }
            else
            {
                Console.WriteLine("Invalid file format. Only .json and .xml formats are supported.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ReadAndPrintJSONFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string jsonData = reader.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(jsonData);

                    Console.WriteLine("Data contained in the JSON file:");
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the JSON file: " + ex.Message);
            }
        }

        private static void ReadAndPrintXMLFile(string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(object));
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    object data = serializer.Deserialize(stream);

                    Console.WriteLine("Data contained in the XML file:");
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the XML file: " + ex.Message);
            }
        }
    }
}

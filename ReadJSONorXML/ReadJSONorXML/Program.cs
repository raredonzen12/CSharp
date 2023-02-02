using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the format of the file (json/xml):");
            string fileFormat = Console.ReadLine().ToLower();
            Console.WriteLine("Enter the path of the file:");
            string filePath = Console.ReadLine();
            try
            {
                if (fileFormat == "json")
                {
                    string jsonContent = File.ReadAllText(filePath);
                    dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);
                    Console.WriteLine(JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented));
                }
                else if (fileFormat == "xml")
                {
                    XDocument xmlDoc = XDocument.Load(filePath);
                    Console.WriteLine(xmlDoc.ToString());
                }
                else
                {
                    Console.WriteLine("Error: Unsupported file format");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }
    }
}

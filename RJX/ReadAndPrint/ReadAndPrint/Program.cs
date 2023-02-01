using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace ReadAndPrintFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file type (JSON or XML): ");
            string fileType = Console.ReadLine();

            Console.WriteLine("Enter the file name: ");
            string fileName = Console.ReadLine();

            if (fileType.ToLower() == "json")
            {
                ReadAndPrintJSONFile(fileName);
            }
            else if (fileType.ToLower() == "xml")
            {
                ReadAndPrintXMLFile(fileName);
            }
            else
            {
                Console.WriteLine("Invalid file type entered.");
            }

            Console.ReadLine();
        }

        static void ReadAndPrintJSONFile(string fileName)
        {
            // Read the contents of the JSON file
            string jsonFile = File.ReadAllText(fileName);

            // Deserialize the JSON file into a dynamic object
            dynamic employees = JsonConvert.DeserializeObject(jsonFile);

            // Iterate over each employee and print their information
            foreach (var employee in employees.company.employee)
            {
                Console.WriteLine("Name: " + employee.name);
                Console.WriteLine("Position: " + employee.position);
                Console.WriteLine("Department: " + employee.department);
                Console.WriteLine();
            }
        }

        static void ReadAndPrintXMLFile(string fileName)
        {
            // Load the XML file into a XDocument
            XDocument xmlDoc = XDocument.Load(fileName);

            // Iterate over each employee element
            foreach (var employee in xmlDoc.Descendants("employee"))
            {
                Console.WriteLine("Name: " + employee.Element("name").Value);
                Console.WriteLine("Position: " + employee.Element("position").Value);
                Console.WriteLine("Department: " + employee.Element("department").Value);
                Console.WriteLine();
            }
        }
    }
}

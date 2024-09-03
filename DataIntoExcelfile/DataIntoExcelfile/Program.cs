using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Bytescout.Spreadsheet;
using System.Diagnostics;
namespace DataIntoExcelfile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spreadsheet datafie = new Spreadsheet();
            Console.WriteLine("enter Your sheet name");
            string sheetname = Console.ReadLine();
            Worksheet sheet = datafie.Workbook.Worksheets.Add(sheetname);
            Console.WriteLine("enter Your nuber of columes");
            int colnumber = int.Parse(Console.ReadLine());
            string[] colid = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"                              };
            string[] colheadingArray = new string[colnumber] ;
            Console.WriteLine("enter Your the headings of the column one by one");
            for (int i = 0; i < colnumber; i++)
            {
                Console.WriteLine($"Enter the {i + 1} column heading");
                string colheading= Console.ReadLine();
                colheadingArray[i] = colheading;
                sheet.Cell($"{colid[i]}1").Value= colheading;
               
            }
            Console.WriteLine("enter the no of rows or no of data ");
            int nodata = int.Parse(Console.ReadLine());

            for (int i = 2; i <= nodata+1; i++) {
                for (int j = 0; j < colheadingArray.Length; j++) {   
                    
                   Console.WriteLine($"ENTER THE {colheadingArray[j]}");                
                    string uservalue = Convert.ToString(Console.ReadLine());
                    sheet.Cell($"{colid[j]}{i}").Value = uservalue;
                }
            }
            Console.WriteLine("write the file name ");
            string filename = Console.ReadLine();
            filename = $"{filename}.xlsx";
            Console.WriteLine("Enter the path where you want to create the file ");
            string filepath = Convert.ToString(Console.ReadLine());
            filepath = $"{filepath}{filename}";
            string path = $"{filepath}";
            FileStream fs = File.Create(path);
            fs.Close();
   
            datafie.SaveAs(path);
            datafie.Close();
            Process.Start(filepath);
        }
    }
}

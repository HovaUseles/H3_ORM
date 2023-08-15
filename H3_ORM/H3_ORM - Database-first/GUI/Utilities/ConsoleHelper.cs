using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Database_first.GUI.Utilities
{
    internal class ConsoleHelper
    {
        public ConsoleHelper()
        {
        }

        public string GetTruncatedSubstring(string text, int maxlength)
        {
            if (text.Length > maxlength)
            {
                return text.Substring(0, maxlength - 3) + "...";
            }
            else
            {
                return text;
            }
        }

        public void WriteAsTableHeaders(string[] headerNames)
        {
            string headersConcat = WriteAsTableCell(headerNames);
            Console.Write("\n"); // start on a new line
            for (int i = 0; i < headersConcat.Count(); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }

        public string WriteAsTableCell(string[] cellValues)
        {
            if (cellValues.Length == 0 || cellValues == null)
            {
                throw new ArgumentNullException(nameof(cellValues), "Cell values names cannot be empty or null.");
            }

            // Creating cell values with spaces to keep same length
            for (int i = 0; i < cellValues.Length; i++)
            {
                cellValues[i] = GetTableCellValue(
                    cellValues[i], 
                    (int)Math.Floor((decimal)(Console.WindowWidth - 3 * cellValues.Length) / cellValues.Length)
                    );
            }
            string headersConcat = string.Join(" | ", cellValues);
            Console.Write(headersConcat);
            return headersConcat;
        }

        private string GetTableCellValue(string cellValue, int columnSize)
        {
            cellValue = GetTruncatedSubstring(cellValue, columnSize-2);
            char[] cellText = new char[columnSize];
            cellText[0] = ' ';
            for (int i = 0; i < cellText.Length - 1; i++)
            {
                if (i < cellValue.Length)
                {
                    cellText[i + 1] = cellValue[i];
                }
                else
                {
                    cellText[i + 1] = ' ';
                }
            }
            cellText[cellText.Length - 1] = ' ';
            return new string(cellText);
        }
    }
}

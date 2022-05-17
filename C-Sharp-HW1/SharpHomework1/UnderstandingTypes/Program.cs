// See https://aka.ms/new-console-template for more information

using UnderstandingTypes;

string header = String.Format("{0,-10} {1, -10} {2, -30} {3, -30}\n", "Type", "Memory", "Minumum", "Maximum");
Console.Write(header);
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "sbyte", "1", "-128", "127");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "byte", "1", "0", "305");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "short", "2", "-32768", "32767");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "ushort", "2", "0", "65535");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "int", "4", "-2,147,483,648", "2,147,483,647");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "uint", "4", "0", "4,294,967,295");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "long", "8", "-9,223,372,036,854,775,808", "9,223,372,036,854,775,807");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "ulong", "8", "0", "18,446,744,073,709,551,615");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "float", "4", "±1.0e-45", "±3.4e38");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "double", "8", "±5e-324", "±1.7e308");
Console.Write("{0,-10} {1, -10} {2, -30} {3, -30}\n", "decimal", "16", "±1.0 ×10e-28", "±7.9e28");
ConvertCentury.Convert(5);

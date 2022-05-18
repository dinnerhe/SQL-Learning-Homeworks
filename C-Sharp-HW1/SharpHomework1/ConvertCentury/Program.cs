// See https://aka.ms/new-console-template for more information

using UnderstandingTypes;
Console.Write("Enter The Number of Centuries: ");
string? input = Console.ReadLine();
uint.TryParse(input, out var result);
ConvertCentury.Convert(result);
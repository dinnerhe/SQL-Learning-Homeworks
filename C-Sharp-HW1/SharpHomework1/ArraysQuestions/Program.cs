// See https://aka.ms/new-console-template for more information

using ArraysQuestions;

/*
CopyArray.Copy();
foreach (string x in ItemManagement.Manage())
{
    Console.WriteLine(x);
}
*/
Console.WriteLine(String.Join(',', FindPrimes.Find(1, 100)));
foreach (int num in Rotate.Run(new int[] { 3, 2, 4, -1 }, 2)) {
    Console.WriteLine(num);
}
Console.WriteLine(String.Join(',', FindLongestSequence.Run(new int[] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 })));
Console.WriteLine(FindFrequentNumber.Run(new int[] {4,1,1,4,2,3,4,4,1,2,4,9,3}));
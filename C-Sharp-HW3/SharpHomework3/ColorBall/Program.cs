// See https://aka.ms/new-console-template for more information
using ColorBall;
Console.WriteLine("Hello, World!");
Ball b1 = new Ball(5, new Color(123, 123, 123));
Ball b2 = new Ball(10, new Color(123, 123, 123));
b1.Throw();
b1.Throw();
Console.WriteLine(b1.GetThrownTime());
Console.WriteLine(b2.GetThrownTime());
b1.Pop();
b1.Throw();
b2.Throw();
b2.Throw();
b2.Throw();
Console.WriteLine(b1.GetThrownTime());
Console.WriteLine(b2.GetThrownTime());
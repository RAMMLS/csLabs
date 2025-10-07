using System;
namespace ConsoleApplication14
{
  class MathOprt
{
  public static void Mul2(double val)
{
 double rslt= val*2;
 Console.WriteLine("Mul2 bсходное значение {0},результат {1}",
val,rslt);
}
public static void Sqr(double val)
{
 double rslt = val*val;
 Console.WriteLine("Sqr исходное значение {0}, результат {1}",
val,rslt);
}
}
delegate void DblOp(double x);//объявление делегата
class Class1
{
[STAThread]
static void Main(string[] args)
{
DblOp operations = new DblOp(MathOprt.Mul2);
operations += new DblOp(MathOprt.Sqr);
Prc(operations, 4.0);
Prc(operations, 9.94);
Prc(operations, 3.143);
}
static void Prc(DblOp act, double val)
{
Console.WriteLine("\n*********\n");
act(val);
}
}
}

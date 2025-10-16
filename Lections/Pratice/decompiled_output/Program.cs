internal class Program
{
	private static void ShowDisplay(CA m)
	{
		m.Display();
	}

	private static void Main(string[] args)
	{
		CA cA = new CA();
		CB cB = new CB();
		cA.Display();
		ShowDisplay(cA);
		cB.Display();
		ShowDisplay(cB);
		cA = cB;
		cA.Display();
		ShowDisplay(cA);
		cB.Display();
		ShowDisplay(cB);
	}
}

using System;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting up");
			Program p = new Program();

			p.Init();
			p.Run();

			Console.WriteLine("\n\nProgram Terminated. Enter to exit.");
			Console.ReadLine();

		}

		private bool Running = false;

		private void Init()
		{
			// Any startup stuff...

			this.Running = true;
		}

		private void Run()
		{
			while(this.Running)
			{
				Console.Clear();
				Console.WriteLine("A. Create new Department");
				Console.WriteLine("B. Change Department Name");
				Console.WriteLine("C. Update Department Manager");
				Console.WriteLine("D. Delete Department");
				Console.WriteLine("E. Get All Departments");
				Console.WriteLine("F. Get Department Information");
				Console.WriteLine("\nX. Exit");

				var key = Console.ReadKey();

				switch(char.ToLower(key.KeyChar))
				{
					case 'a':
					case 'b':
					case 'c':
					case 'd':
					case 'e':
					case 'f':
					default:
						Console.WriteLine("Unknown Menu Option.");
						break;

					case 'x':
						Running = false;
						break;
				}
			}
		}
	}
}

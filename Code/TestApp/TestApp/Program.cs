using Domain.Entities;
using Domain.Repository;
using Infrastructure.Repository;
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
        private IRepository db;

		private void Init()
		{
            // Any startup stuff...
            db = new Repository();

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
                Console.Clear();

                var result = "";
                switch (char.ToLower(key.KeyChar))
				{
					case 'a':
                        Console.WriteLine(db.Create(null));
                        break;
                    case 'b':
                        Console.WriteLine(db.UpdateName(null));
                        break;
                    case 'c':
                        Console.WriteLine(db.UpdateManager(null));
                        break;
                    case 'd':
                        DeleteDep();
                        break;
                    case 'e':
                        GetAllDep();
                        break;
                    case 'f':
                        
                        result = GetDepInfo();
                        break;
                    default:
						Console.WriteLine("Unknown Menu Option.");
						break;

					case 'x':
						Running = false;
						break;
				}

                Console.ReadKey();
			}
		}

        private void DeleteDep()
        {
            Console.WriteLine("Enter the id of the Department you want to delete");
            try
            {
                int DNumber;
                var success = Int32.TryParse(Console.ReadLine(), out DNumber);
                Console.Write("Deleting ");
                Console.WriteLine(db.Get(DNumber).ToString());

                db.Delete(DNumber);
                Console.WriteLine("The item has been removed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private void GetAllDep()
        {
            foreach (var item in db.Get())
            {
                Console.WriteLine(item);
            }
        }

        private string GetDepInfo(int DNumber)
        {
            string result;
            Console.WriteLine("Enter the id of the Department you want");
            int DNumber;
            var success = Int32.TryParse(Console.ReadLine(), out DNumber);
            try
            {
                result = db.Get(DNumber).ToString();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Console.WriteLine(result);
            return result;
        }
    }
}

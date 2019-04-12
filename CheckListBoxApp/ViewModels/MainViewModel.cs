using System.Linq;

namespace CheckListBoxApp.ViewModels
{
	public class MainViewModel
	{
		public MainViewModel()
		{
			PersonVMs = Enumerable.Range(0, 10).Select(x => new PersonViewModel {Name = $"Person #{x}"}).ToArray();
			AnimalVMs = Enumerable.Range(0, 10).Select(x => new AnimalViewModel { Name = $"Animal #{x}"}).ToArray();
			ShapeVMs = Enumerable.Range(0, 10).Select(x => new ShapeViewModel { Name = $"Shape #{x}"}).ToArray();
		}

		public PersonViewModel[] PersonVMs { get; }
		public AnimalViewModel[] AnimalVMs { get; }
		public ShapeViewModel[] ShapeVMs { get; }
	}
}
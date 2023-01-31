class ViewReadLecture : IView, IObserver {
	private IObservables _model;
	private int numPage;
	private string textToShow;
	public ViewReadLecture(IObservables model) {
		_model = model;
		_model.Register(this);
		numPage = 1;
	}

	public void Update(string input) {
		switch (input)
		{
		case "empty":
			PrintPagesIsEmpty();
			PrintNavigationWhenPagesEmpty();
			break;
		case "done":
			PrintPagesIsOver();
			PrintNavigationWhenPagesOver();
			break;
		default:
			PrintNavigation();
			textToShow = "Страница " + (numPage++) + ":\n";
			textToShow += input;
			Print();
			break;
		}
	}

	public void Print() {
		Console.WriteLine(textToShow);
	}

	private void PrintNavigation() {
		Console.WriteLine("Навигация по страницам: ");
		Console.WriteLine("1 - Следующая страница");
		Console.WriteLine("2 - Предыдущая страница");
		Console.WriteLine("3 - К лекциям");
		Console.WriteLine("4 - Добавить страницу");
		Console.WriteLine("0 - В главное меню");
		Console.WriteLine();
	}

	private void PrintPagesIsEmpty() {
		Console.WriteLine("Эта лекция пуста");
		Console.WriteLine();
	}

	private void PrintNavigationWhenPagesEmpty(){
		Console.WriteLine("3 - К лекциям");
		Console.WriteLine("4 - Добавить страницу");
		Console.WriteLine("0 - В главное меню");
		Console.WriteLine();
	}

	private void PrintNavigationWhenPagesOver(){
		Console.WriteLine("2 - Предыдущая страница");
		Console.WriteLine("3 - К лекциям");
		Console.WriteLine("4 - Добавить страницу");
		Console.WriteLine("0 - В главное меню");
		Console.WriteLine();
	}

	private void PrintPagesIsOver(){
		Console.WriteLine("Это была последняя страница");
		Console.WriteLine();
	}
}
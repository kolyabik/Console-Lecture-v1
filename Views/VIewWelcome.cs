class ViewWelcome : IView, IObserver {
	private IObservables _model;
	public ViewWelcome(IObservables model) {
		_model = model;
		_model.Register(this);
	}

	public void Update(string input) {
		Print();
	}
	public void Print() {
		Console.WriteLine("Здравствуйте, пожалуйста " +
		                  "выберите нужное из списка:");
		Console.WriteLine("1. Посмотреть доступные лекции.");
		Console.WriteLine("2. Создать лекцию.");
		Console.WriteLine("3. Выйти из приложения.");
		Console.WriteLine("Сделав выбор, напишите нужную цифру");
	}
}

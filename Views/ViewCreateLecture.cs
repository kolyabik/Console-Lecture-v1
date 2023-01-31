class ViewCreateLecture : IView, IObserver {
	private IObservables _model;

	public ViewCreateLecture(IObservables model) {
		_model = model;
		_model.Register(this);
	}

	public void Update(string input) {
		switch (input)
		{
		case "start":
			Print();
			break;
		case "mistake":
			PrintMistake();
			break;	
		default:
			PrintSuccess(input);
			break;
		}
	}

	public void Print() {
		Console.WriteLine("Пожалуйста, напишите название лекции");
	}

	private void PrintSuccess(string nameLecture){
		Console.WriteLine("Леция "+nameLecture+" успешно создана");
		Console.WriteLine();
	}

	private void PrintMistake(){
		Console.WriteLine("Такая лекция уже существует, выберете другое название");
		Console.WriteLine();
	}
}
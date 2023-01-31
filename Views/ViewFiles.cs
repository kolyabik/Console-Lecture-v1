
class ViewFiles : IView, IObserver {
	private IObservables _model;
	private string lecture;
	private int numberLecture = 1;
	public ViewFiles(IObservables model) {
		_model = model;
		_model.Register(this);
	}

	public void Update(string input) {
		if (!(input == "done" || input == "empty" )) {
			if (numberLecture == 1) {
				Console.Clear();
				Console.WriteLine("Список доступных лекций, чтобы выбрать лекцию, введите ее номер");
			}
			this.lecture = (numberLecture++) + "." + " " + input;
			Print();
		} else if (input == "empty") {
			Console.WriteLine("Нет доступных лекций, хотите их создать?");
			Console.WriteLine("y или n");
		} else if (input == "done")
			Console.WriteLine("Чтобы вернуться обратно в главное меню введите 0");
	}

	public void Print() {
		Console.WriteLine(lecture);
	}
}

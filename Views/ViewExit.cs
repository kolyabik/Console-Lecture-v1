class ViewExit : IView, IObserver{
	private IObservables _model;
	public ViewExit(IObservables model){
		_model = model;
		_model.Register(this);
	}

	public void Update(string input){
		Print();
	}

	public void Print(){
		Console.WriteLine("Спасибо, что использовали приложение!");
		Console.WriteLine();
	}
}
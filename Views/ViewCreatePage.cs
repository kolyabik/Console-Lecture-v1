class ViewCreatePage : IView, IObserver{
	private IObservables _model;
	public ViewCreatePage(IObservables model){
		_model = model;
		_model.Register(this);
	}


	public void Update(string input){
		Print();
	}

	public void Print(){
		Console.WriteLine("Страница добавлена, желаете записать в нее сожержимое?");
		Console.WriteLine("y or n");
	}
}
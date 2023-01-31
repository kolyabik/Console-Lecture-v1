class ModelCreatePage : IModel, IObservables{
	private List<IObserver> _views;
	private string currentLecture;
	private ICreater creater;
	private string someInput = "";

	public ModelCreatePage(string path){
		_views = new List<IObserver>();
		currentLecture = path;
		creater = new Creater();
	}

	public void Notify(string input){
		foreach (var view in _views) 
		{
			view.Update(input);
		}
	}
	public void Register(IObserver view){
		_views.Add(view);
	}
	

	public void Remove(IObserver view){
		_views.Remove(view);
	}

	public void DoJob(){
		creater.CreatePage(currentLecture);
		Notify(someInput);
	}
}
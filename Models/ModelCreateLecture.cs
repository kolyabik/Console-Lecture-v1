class ModelCreateLecture : IModel, IObservables{
	private List<IObserver> _views;
	private ICreater creater;
	private string nameLecture;
	private string start = "start";
	private string mistake = "mistake";

	public ModelCreateLecture(string name){
		_views = new List<IObserver>();
		creater = new Creater();
		nameLecture = name;
	}

	public void Notify(string input) {
		foreach (var view in _views)
		{
			view.Update(input);
		}
	}

	public void Register(IObserver view) {
		_views.Add(view);
	}

	public void Remove(IObserver view) {
		_views.Remove(view);
	}


	public void DoJob() {
		int someNum = 0;
		if((int.TryParse(nameLecture, out someNum)) || (nameLecture == "y")){
			Notify(start);
		} else if(creater.CreateLecture(nameLecture)){
			Notify(nameLecture);
		} else 
			Notify(mistake);
	}
}
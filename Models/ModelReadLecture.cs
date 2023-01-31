class ModelReadLecture : IModel, IObservables {
	private string path;
	private List<IObserver> _views;
	private string[] pages;
	private int currentNumPage;
	private string pagesIsEmpty = "empty";
	private string pagesIsOver = "done";

	public ModelReadLecture(string path) {
		_views = new List<IObserver>();
		this.path = path;
		pages = GetPages(path);
		currentNumPage = 0;
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
		if (pages.Length > 0) {
			if (currentNumPage + 1 <= pages.Length) {
				Notify(GetTextFromLecture(pages[currentNumPage++]));
			} else {
				Notify(pagesIsOver);
			}
		} else {
			Notify(pagesIsEmpty);
		}
	}

	private string[] GetPages(string path) {
		return Directory.GetFiles(path);
	}

	private string GetTextFromLecture(string path) {
		return File.ReadAllText(path);
	}

}
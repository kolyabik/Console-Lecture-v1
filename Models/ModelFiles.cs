class ModelFiles : IModel, IObservables {
	private List<IObserver> subs;
	private string LecturesIsEmpty = "empty";
	private string LecturesIsOver = "done";
	private ICreater creater;
	public ModelFiles() {
		subs = new List<IObserver>();
		creater = new Creater();
		creater.CreateList();
	}

	public void Notify(string input) {
		foreach (var sub in subs)
		{
			sub.Update(input);
		}
	}

	public void Register(IObserver view) {
		subs.Add(view);
	}

	public void Remove(IObserver view) {
		subs.Remove(view);
	}

	public void DoJob() {
		FindLecturers();
	}


	private void FindLecturers() {
		string path = "C:\\Users\\kolya\\Desktop\\studing\\c#\\ConsoleLecture\\Lecture";
		string[] directories = Directory.GetFileSystemEntries(path);
		if (directories.Length > 0) {
			for (int i = 0; i < directories.Length; i++) {
				string nameLecture = directories[i].Substring(path.Length + 1);
				if (nameLecture.StartsWith("L_")) {
					creater.AddToList(directories[i]);
					Notify(nameLecture.Substring(2));
				}
				if (i == directories.Length - 1) {
					Notify(LecturesIsOver);
				}
			}
		} else
			Notify(LecturesIsEmpty);
	}
}

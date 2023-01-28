class ModelFiles : IModel, IObservables {
	private List<IObserver> subs;
	private string LecturesIsEmpty = "empty";
	private string LecturesIsOver = "done";
	public ModelFiles() {
		subs = new List<IObserver>();
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
				if (directories[i].Substring(path.Length+1).StartsWith("L_")) {
					Notify(directories[i].Substring(path.Length+3));
				}
				if (i == directories.Length - 1) {
					Notify(LecturesIsOver);
				}
			}
		} else
			Notify(LecturesIsEmpty);
	}
}

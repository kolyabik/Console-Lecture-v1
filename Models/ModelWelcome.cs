class ModelWelcome : IModel, IObservables {
	private List<IObserver> subs;
	private string justString = "";

	public ModelWelcome() {
		subs = new List<IObserver>();
	}
	public void DoJob() {
		Notify(justString);
	}

	public void Notify(string input) {
		foreach (var sub in subs) {
			sub.Update(input);
		}
	}

	public void Register(IObserver sub) {
		subs.Add(sub);
	}

	public void Remove(IObserver sub) {
		subs.Remove(sub);
	}
}

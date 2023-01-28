class ModelExit : IModel, IObservables{
	private List<IObserver> subs;
	private string justString = "";
	
	public ModelExit(){
		subs = new List<IObserver>();
	}

	public void Notify(string input){
		foreach (var sub in subs) 
		{
			sub.Update(input);
		}
	}

	public void Register(IObserver view){
		subs.Add(view);
	}

	public void Remove(IObserver view){
		subs.Remove(view);
	}

	public void DoJob(){
		Notify(justString);
	}
}
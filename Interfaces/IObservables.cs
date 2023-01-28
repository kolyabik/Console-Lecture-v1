interface IObservables {
	void Notify(string input);
	void Register(IObserver view);
	void Remove(IObserver view);
}

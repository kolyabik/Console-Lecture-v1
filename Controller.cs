class Controller {
	private string userInput;
	private IModel _model;
	private IView _view;
	private int _userInput;
	private IFinder finder;
	private string currentLecture;

	public Controller() {
		Welcome();
		this.userInput = Console.ReadLine();
		ProcessedUserInput(userInput);
		finder = new Finder();
	}

	private void ProcessedUserInput(string userInput) {
		//start programm check user input
		Console.Clear();
		switch (_model)
		{
		// main menu choose
		case (ModelWelcome):
			if (int.TryParse(userInput, out _userInput)) {
				switch (_userInput)
				{
				// show all lectures
				case 1:
					_model = new ModelFiles();
					_view = new ViewFiles(_model as IObservables);
					_model.DoJob();
					_userInput = 0;
					break;
				// create new lecture
				case 2:
					_model = new ModelCreateLecture(userInput);
					_view = new ViewCreateLecture(_model as IObservables);
					_model.DoJob();
					break;
				// exit from app
				case 3:
					ExitFromApp();
					Environment.Exit(0);
					break;
				default:
					Error();
					break;
				}
			} else
				Error();
			break;

		// if user choose 1 from start of app(show all lectures)
		case (ModelFiles):
			if (int.TryParse(userInput, out _userInput)) {
				switch (_userInput)
				{
				// to main menu
				case 0:
					Welcome();
					_userInput = 0;
					break;
				// to any lecture
				default:
					currentLecture = finder.FindLecture(_userInput);
					_model = new ModelReadLecture(currentLecture);
					_view = new ViewReadLecture(_model as IObservables);
					_model.DoJob();
					break;
				}

			} else if ((userInput == "y") || (userInput == "n") ) {
				if (userInput == "y") {
					_model = new ModelCreateLecture(userInput);
					_view = new ViewCreateLecture(_model as IObservables);
					_model.DoJob();
				} else
					Welcome();
			} else
				Error();
			break;
		// when user see lecture text
		case (ModelReadLecture):
			if (int.TryParse(userInput, out _userInput)) {
				switch (_userInput)
				{

				case 0:
					Welcome();
					break;
				case 1:
					_model.DoJob();
					break;
				case 2:
					_model = new ModelCreateLecture(userInput);
					_view = new ViewCreateLecture(_model as IObservables);
					_model.DoJob();
					break;
				case 3:
					_model = new ModelFiles();
					_view = new ViewFiles(_model as IObservables);
					_model.DoJob();
					break;
				case 4:
					_model = new ModelCreatePage(currentLecture);
					_view = new ViewCreatePage(_model as IObservables);
					_model.DoJob();
					break;
				}
			} else
				Error();
			break;
		case (ModelCreateLecture):
			_model = new ModelCreateLecture(userInput);
			_view = new ViewCreateLecture(_model as IObservables);
			_model.DoJob();
			Welcome();
			break;
		case (ModelCreatePage):
			if ((userInput == "y") || (userInput == "n")) {
				if (userInput == "y") {
					ProgramInDevelopment();
					Welcome();
				} else
					Welcome();
			} else
				Error();
			break;
		}
	}

	public void Repeat() {
		userInput = Console.ReadLine();
		ProcessedUserInput(userInput);
	}

	private void Error() {
		Console.WriteLine("Пожалуйста проверьте правильность ввода");
	}

	private void ProgramInDevelopment() {
		Console.WriteLine("Этот функционал в доработке");
	}

	private void Welcome() {
		_model = new ModelWelcome();
		_view = new ViewWelcome(_model as IObservables);
		_model.DoJob();
	}

	private void ExitFromApp() {
		_model = new ModelExit();
		_view = new ViewExit(_model as IObservables);
		_model.DoJob();
	}


}

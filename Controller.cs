class Controller {
	private string userInput;
	private IModel _model;
	private IView _view;
	private int _userInput;

	public Controller() {
		Welcome();
		userInput = Console.ReadLine();
		ProcessedUserInput(userInput);
	}

	private void ProcessedUserInput(string userInput) {
		//start programm check user input

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
					ProgramInDevelopment();
					_userInput = 0;
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
				  	
					break;
				}

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

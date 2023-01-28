class Program {
	public static void Main(String[] args) {
		Controller c = new Controller();
		ICreater cr = new Creater();
		cr.CreateList();		
		while (true) {
			c.Repeat();
		}
	}
}

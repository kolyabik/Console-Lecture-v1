class Finder : IFinder {
	private string lectureListPath;
	public Finder() {
		lectureListPath = Directory.GetCurrentDirectory() + "/LectureList.txt";
	}

	public bool IsLectureExists(string path) {
		using (var reader = new StreamReader(lectureListPath)) {
			string inputLine;
			while ((inputLine = reader.ReadLine()) != null) {
				if (inputLine == path) {
					reader.Close();
					Console.WriteLine(reader.ReadLine());
					return true;
				}
			}
			reader.Close();
		}
		return false;
	}

	public string GetLectureListPath() {
		return lectureListPath;
	}
}
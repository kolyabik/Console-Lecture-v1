class Finder : IFinder {
	private string pathToDirWithLectures;
	public Finder() {
		pathToDirWithLectures = Directory.GetCurrentDirectory() + "\\Lecture";
		CheckIsLectureFolderIsCreated();
	}

	public string FindLecture(int numLecture) {
		string[] lectures = Directory.GetFileSystemEntries(pathToDirWithLectures);
		int trueNumLecture = 1;
		for (int i = 0; i < lectures.Length; i++) {
			if (lectures[i].Substring(pathToDirWithLectures.Length + 1).StartsWith("L_")) {
				if (trueNumLecture == numLecture) {
					return lectures[i];
				} else {
					trueNumLecture++;
				}
			}
		}
		return null;
	}

	public string GetPathIntoCurrentLecture() {
		return pathToDirWithLectures + "\\";
	}

	public string GetPathLectureFolder(){
		return pathToDirWithLectures;
	}

	public bool SearchMatches(string path, string searching) {
		string[] entries = Directory.GetFileSystemEntries(path);
		foreach (var entry in entries)
		{
			if (searching == entry) {
				return true;
			}
		}
		return false;
	}


	private void CheckIsLectureFolderIsCreated() {
		if (Directory.Exists(pathToDirWithLectures)) {

		} else {
			Directory.CreateDirectory(pathToDirWithLectures);
		}
	}

}
class Finder : IFinder {
	private string pathToDirWithLectures;
	public Finder() {
		pathToDirWithLectures = "C:\\Users\\kolya\\Desktop\\studing\\c#\\ConsoleLecture\\Lecture";
	}

	public string FindLecture(int numLecture) {
		string[] lectures = Directory.GetFileSystemEntries(pathToDirWithLectures);
		int trueNumLecture = 1;
		for (int i = 0; i < lectures.Length; i++) {
			if (lectures[i].Substring(pathToDirWithLectures.Length+1).StartsWith("L_")) {
				if (trueNumLecture == numLecture) {
					return lectures[i];
				} else {
					trueNumLecture++;
				}
			}
		}
		return null;
	}

	public string GetPathLectures(){
		return pathToDirWithLectures+"\\";
	}

	public bool SearchMatches(string path,string searching){
		string[] entries = Directory.GetFileSystemEntries(path);
		foreach (var entry in entries) 
		{
			if(searching == entry){
				return true;
			}
		}
		return false;
	}

}
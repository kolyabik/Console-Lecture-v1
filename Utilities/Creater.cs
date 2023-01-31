using System.IO;
class Creater : ICreater {
	private string pathToLectures;
	private IFinder finder;
	public Creater() {
		finder = new Finder();
		pathToLectures = finder.GetPathLectures();
	}

	public bool CreateLecture(string name) {
		string nameLecture = pathToLectures + "L_";
		nameLecture += name;
		if (finder.SearchMatches(pathToLectures, nameLecture)) {
			return false;
		} else {
			Directory.CreateDirectory(nameLecture);
			return true;
		}
	}


	public void CreatePage(string path) {
		string[] files = Directory.GetFiles(path);
		string currentPage = "";
		if (files.Length > 0) {
			int lastNumPage = 1;
			foreach (var file in files)
			{
				if (file.Substring(path.Length + 1).StartsWith("P_")) {
					lastNumPage = Int32.Parse(Path.GetFileNameWithoutExtension(file.Substring(path.Length + 3)));
				}
			}
			currentPage = path + "\\P_" + (++lastNumPage)+".txt";
			File.Create(currentPage);
		} else{
			currentPage = path+"\\P_1.txt";
			File.Create(currentPage);
		}
	}

}
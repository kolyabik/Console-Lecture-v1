using System.IO;
class Creater : ICreater {
	private IFinder finder;
	private string lectureListPath;
	public Creater() {
		finder = new Finder();
		lectureListPath = finder.GetLectureListPath();
	}
	public void CreateList() {
		File.CreateText(lectureListPath);
	}

	public void AddToList(string path) {
		if (!finder.IsLectureExists(path)) {
			File.AppendAllText(lectureListPath, path + Environment.NewLine);
		}
	}

	public string GetAllList() {
		return File.ReadAllText(lectureListPath);
	}
}
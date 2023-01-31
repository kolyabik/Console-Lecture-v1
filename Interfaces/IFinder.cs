interface IFinder 
{
	string FindLecture(int numLecture);
	string GetPathIntoCurrentLecture();
	string GetPathLectureFolder();
	//return true if matches will detected
	bool SearchMatches(string path,string searching);

}
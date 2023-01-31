interface IFinder 
{
	string FindLecture(int numLecture);
	string GetPathLectures();
	//return true if matches will detected
	bool SearchMatches(string path,string searching);

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FileHandler : MonoBehaviour {
	// Load and Save Data
	// Use this for initialization
	public static string savePath = "Resources/Text/";
	public static string fileExtension = ".txt";

    public static List<string> PrintTxt(string s)
    {
        string tmps;
        StringReader read = null;
        TextAsset file = Resources.Load("Text/dta.txt") as TextAsset;
        read = new StringReader(s);
        List<string> Lines = new List<string>();
        for(int i = 0; i < 39; i++)
        {
            Lines.Add(read.ReadLine());
        }

        return Lines;
    }

	public static List<string> LinesofFile(string filePath, bool removeblanklines = true)
	{
        //filePath = AttemptCorrectFilePath (filePath);
        //string content = GetRawFileContent(filePath);
       // string file = "dta.txt";
        if (File.Exists (filePath)) {
			string content = GetRawFileContent (filePath);
			List<string> Lines = GetLinesFromContent (content, removeblanklines);
			return Lines;
		} else {
			string errorMessage = " ERROR! File " + filePath + "Does not exsist";
			Debug.LogError (errorMessage);
			return new List<string>(){errorMessage};
		}
	}

	static string AttemptCorrectFilePath(string filePath){

		filePath = filePath.Replace ("[]", savePath);

		if (!filePath.Contains ("."))
			filePath += fileExtension;

		return filePath;
	}
	public static void SaveFileWithLines(string filePath, List<string> lines)
	{
		filePath = AttemptCorrectFilePath (filePath);

		TryCreateDirectoryFromPath (filePath);

		StreamWriter sw = new StreamWriter (filePath);
		int i = 0;
		for (i = 0; i < lines.Count; i++) {
			sw.WriteLine (lines [i]);
		}
		sw.Close ();

		print ("Saved" + i.ToString () + " lines to file[" + filePath + "]");
	}
	static string GetRawFileContent( string filePath){
		StreamReader sr = new StreamReader (filePath);
		string content = sr.ReadToEnd ();
		sr.Dispose ();

		return content;
	}
	public static List<string> GetLinesFromContent(string content, bool removeblanklines = true){
		string[] splitLines = RemoveNewLineReadLine(content);
		List<string> trueList = ArrayToList(splitLines, removeblanklines);
		return trueList;
	}

	static string[] RemoveNewLineReadLine(string content) {

		string[] splitLines;
		char[] splitters = new char[]{'\n','\r'};
		splitLines = content.Split (splitters);
		return splitLines;
	}

	static List<string> ArrayToList(string[] array, bool removeblanklines = true){
		List<string> list = new List<string> ();
		for (int i = 0; i < array.Length; i++) {
			string s = array [i];
			if (s.Length > 0 || !removeblanklines) {
				list.Add (s);
			}
		}
		return list;
	}

	public static bool TryCreateDirectoryFromPath (string path)
	{
		string directoryPath = path;

		if (Directory.Exists (path) || File.Exists (path))
			return true;

		if (path.Contains (".")) 
		{
			directoryPath = "";
			string[] parts = path.Split ('/');
			foreach (string part in parts) 
			{
				if (!part.Contains ("."))
					directoryPath += part + "/";
			}
			if (Directory.Exists (directoryPath))
				return true;
		}

		if (directoryPath != "" && !directoryPath.Contains ("."))
		{
				Directory.CreateDirectory (directoryPath);
				return true;
			} 
			else 
			{
				Debug.LogError ("Directory was invalid - " + directoryPath);
				return false;
			}
	}

	public static bool DirectoryExist(string path){
		path =	AttemptCorrectFilePath (path);
		return Directory.Exists (path);
	}
	public static bool FileExist(string Path){
		Path =	AttemptCorrectFilePath (Path);
		return File.Exists (Path);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

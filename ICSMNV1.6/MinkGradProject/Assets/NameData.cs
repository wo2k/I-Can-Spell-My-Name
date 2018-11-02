using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameData : MonoBehaviour {

	public string datFile = "[]dta.txt";
	public List<string> data = new List<string>();
	// Use this for initialization
	void Start () {

		if (!FileHandler.FileExist (datFile)) {
			FileHandler.SaveFileWithLines (datFile, new List<string> (){ "line1", "line2", "line3" });
		}
		data = FileHandler.LinesofFile (datFile);
	}
	public void AddName (string name) {
		for (int i = 0; i < data.Count; i++)
			if (name == data [i])
				return;

		data.Add (name);
	}
    public string GetName(string name)
    {
        if (data.Contains(name))
            return name;
        else
        {
            Debug.LogError("Tried retrieving a name that is not in name file");
            return null;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

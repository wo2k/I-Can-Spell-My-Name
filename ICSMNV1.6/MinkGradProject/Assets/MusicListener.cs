using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicListener : MonoBehaviour {
	AudioSource MyAudio;
	private UnityAction Level1A;
	private UnityAction Level1B;
	private UnityAction Level2;
	private UnityAction Level3;

	public List<AudioClip> Music;
	// Use this for initialization

	void Start () {
		MyAudio = GetComponentInChildren<AudioSource>();
        SoundManagement.instance.musicName = MyAudio.clip.name;
	}
	void Awake(){
		Level1A = new UnityAction (PlayLevel1A);
		Level1B = new UnityAction (PlayLevel1B);
		Level2 = new UnityAction (PlayLevel2);
		Level3 = new UnityAction (PlayLevel3);
	}
	void OnDisable(){
		SoundManagement.Stoplistening ("PlayLevel1A",  Level1A);
		SoundManagement.Stoplistening ("PlayLevel1B", Level1B);
		SoundManagement.Stoplistening ("PlayLevel2", Level2);
		SoundManagement.Stoplistening ("PlayLevel3", Level3);
	}
	void OnEnable(){
		SoundManagement.Startlistening ("PlayLevel1A", Level1A);
		SoundManagement.Startlistening ("PlayLevel1B", Level1B);
		SoundManagement.Startlistening ("PlayLevel2", Level2);
		SoundManagement.Startlistening ("PlayLevel3", Level3);
	
	}
	void PlayLevel1A(){
		MyAudio.Stop ();
		MyAudio.clip = Music [0];
		MyAudio.Play ();
		Debug.Log ("1A");
	}
	void PlayLevel1B(){
		MyAudio.Stop ();
		MyAudio.clip = Music [1];
		MyAudio.Play ();
		Debug.Log ("1B");
	}
	void PlayLevel2(){
		MyAudio.Stop ();
		MyAudio.clip = Music [2];
		MyAudio.Play ();
		Debug.Log ("2");
	}
	void PlayLevel3(){
		MyAudio.Stop ();
		MyAudio.clip = Music [3];
		MyAudio.Play ();
		Debug.Log ("3");
	}

	// Update is called once per frame
	void Update () {
        SoundManagement.instance.musicName = MyAudio.clip.name;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateSound : MonoBehaviour {


	AudioSource audio;

	public AudioSource audioRecord;
	public AudioSource audioMusic;
	public AudioSource audioSfx;

	public Slider MusicSlider;
	public Slider SfxSlider;

	IEnumerator Start() {
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {
		} else {
		}
	}
	// Use this for initialization

	public void OnRecord(){
		audio = GetComponent<AudioSource> ();
		audio.clip = Microphone.Start ("Built-in Microphone", true, 5, 44100);

	}
	public void OnPlay(){
		audio.Play ();
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateSounds() {

		audioRecord.volume = MusicSlider.value;
		audioMusic.volume = MusicSlider.value;
		audioSfx.volume = SfxSlider.value;
		PlayerPrefs.SetFloat ("SFXVolume", SfxSlider.value);
		PlayerPrefs.SetFloat ("MusicVolume", MusicSlider.value);
	}

}

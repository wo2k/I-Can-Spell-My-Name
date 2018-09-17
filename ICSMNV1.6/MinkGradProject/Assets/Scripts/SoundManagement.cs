using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SoundManagement : MonoBehaviour {
	private Dictionary <string,UnityEvent> eventDictionary;

	private float SFXVolume = 0.5f;
	private float MusicVolume = 0.5f;
	public AudioSource SFXSource;
	public AudioSource MusicSource;

	private static SoundManagement eventManager;
	public static SoundManagement instance
	{
		get 
		{ 
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof(SoundManagement)) as SoundManagement;
				if (!eventManager) 
				{
					Debug.Log ("Needs a EventSystem");
				} else 
				{
					eventManager.Init();
				}

			}
			return eventManager;
		}
	}
	// Use this for initialization
	void Start() {
		SFXVolume = PlayerPrefs.GetFloat ("SFXVolume");
		MusicVolume = PlayerPrefs.GetFloat ("MusicVolume");

		MusicSource.volume = MusicVolume;
		SFXSource.volume = SFXVolume;
	}
	void Init(){
		if (eventDictionary == null) 
		{
			eventDictionary = new Dictionary<string,UnityEvent> ();
		}
	}

	public static void Startlistening(string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener (listener);
		} else {
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}
	public static void Stoplistening(string eventName, UnityAction listener)
	{
		if (eventManager == null)
			return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent(string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.Invoke();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

}

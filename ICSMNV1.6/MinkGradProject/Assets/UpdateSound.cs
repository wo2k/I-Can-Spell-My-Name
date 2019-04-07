using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateSound : MonoBehaviour {


	AudioSource m_Audio;

	public AudioSource audioRecord;
	public AudioSource audioMusic;
	public AudioSource audioSfx;

	public Slider MusicSlider;
	public Slider SfxSlider;

    public float musicVolume = 0.1f;
    public float sfxVolume = 0.1f;

    void Start()
    {
        if (!LevelManager.instance.toggleVibration)
            LevelManager.instance.toggleVibration = GameObject.Find("Toggle");

        if (LevelManager.instance.m_Console != LevelManager.AppPlatform.iPhone || LevelManager.instance.m_Console != LevelManager.AppPlatform.Andriod)
            LevelManager.instance.toggleVibration.SetActive(false);

         if (LevelManager.instance.m_Console == LevelManager.AppPlatform.iPhone)
         LevelManager.instance.toggleVibration.SetActive(true);

        if (!audioSfx)
            audioSfx = FindObjectOfType<LevelManager>().gameObject.GetComponent<AudioSource>();
        if (!audioMusic)
            audioMusic = FindObjectOfType<LevelManager>().gameObject.GetComponent<AudioSource>();
        /*Retrieves saved Music Volume___________________________Retrieves saved Music Slider Value*//////////////////////////
        audioMusic.volume = PlayerPrefs.GetFloat("MusicVolume"); MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");////
        /*Retrieves saved Music Volume___________________________Retrieves saved Music Slider Value*/////////////////////////

        /*Retrieves saved SfX Volume___________________________Retrieves saved SfX Slider Value*//////////////////////////
        audioSfx.volume = PlayerPrefs.GetFloat("SFXVolume");     SfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");/////
        /*Retrieves saved SfX Volume___________________________Retrieves saved SfX Slider Value*//////////////////////////

        UIManager.instance.mode = UIManager.subLevels1.None;
        UIManager.instance.mode2 = UIManager.subLevels2.None;
    }

    #region Do we need this?
    /*IEnumerator Start()
    {
       

		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		if (Application.HasUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone)) {
		} else {
		}
	}*/
    #endregion Do we need this?

    public void OnRecord(){
		m_Audio = GetComponent<AudioSource> ();
		m_Audio.clip = Microphone.Start ("Built-in Microphone", true, 5, 44100);

	}
	public void OnPlay(){
		m_Audio.Play ();
	}
	// Update is called once per frame
	void Update ()
    {
        /*Sets Music Volume____________________Saves Music Slider Value*///////////////////////////////////
        audioMusic.volume = MusicSlider.value; PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);/////
        /*Sets Music Volume____________________Saves Music Slider Value*///////////////////////////////////

        /*Sets SfX Volume______________________Saves SfX Slider Value*/////////////////////////////////////
        audioSfx.volume = SfxSlider.value;     PlayerPrefs.SetFloat("SFXVolume", SfxSlider.value);/////////
        /*Sets SfX Volume______________________Saves SfX Slider Value*/////////////////////////////////////


    }

    #region Legacy Function
    public void UpdateSounds() {

		audioRecord.volume = MusicSlider.value;
		audioMusic.volume = MusicSlider.value;
		audioSfx.volume = SfxSlider.value;
		PlayerPrefs.SetFloat ("SFXVolume", SfxSlider.value);
		PlayerPrefs.SetFloat ("MusicVolume", MusicSlider.value);
	}
    #endregion Legacy Function

    public void SetMusicVolume(float sliderVal)
    {
        musicVolume = sliderVal;      
    }

    public void SetSfxVolume(float sliderVal)
    {
        sfxVolume = sliderVal;       
    }

    public void CloseApplication()
    {
        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.Windows)
        {
#if UNITY_EDITOR
            if (Application.platform == RuntimePlatform.WindowsEditor)
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            if (Application.platform == RuntimePlatform.WindowsPlayer)
                Application.Quit();
        }

        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.MacOS)
        {
#if UNITY_EDITOR
            if (Application.platform == RuntimePlatform.OSXEditor)
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            if (Application.platform == RuntimePlatform.OSXPlayer)
                Application.Quit();
        }
    }
}

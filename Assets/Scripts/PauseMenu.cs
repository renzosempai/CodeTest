using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseMenuUI;
	public GameObject optionsMenuHolder;


	public Slider[] volumeSliders;
	public Toggle[] resolutionToggles;
	public Toggle fullscreenToggle;
	public int[] screenWidths;
	int activeScreenResIndex;

	public static bool GameIsPaused = false;

	// Use this for initialization
	void Start () {
		activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
		bool isFullscreen = (PlayerPrefs.GetInt ("fullscreen") == 1) ? true : false;

		for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].isOn = i == activeScreenResIndex;
		}

		fullscreenToggle.isOn = isFullscreen; 
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused) {	
				Resume ();
			} 
			else {
				Pause ();
			}
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	
	}

//	public void LoadMenu(){
//		Debug.Log ("Loading Main Menu.....");
//	}

	public void ExitToMainMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Start Menu");
	}

	public void OptionstoPause(){
		pauseMenuUI.SetActive (true);
		optionsMenuHolder.SetActive (false);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void OptionsMenu() {
		pauseMenuUI.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}

	public void SetScreenResolution(int i) {
		if (resolutionToggles [i].isOn) {
			activeScreenResIndex = i;
			float aspectRatio = 16 / 9f;
			Screen.SetResolution (screenWidths [i], (int)(screenWidths [i] / aspectRatio), false);
			PlayerPrefs.SetInt ("screen res index", activeScreenResIndex);
		}
	}

	public void SetFullScreen(bool isFullscreen) {
		for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].interactable = !isFullscreen;
		}
		if (isFullscreen) {
			Resolution[] allResolutions = Screen.resolutions;
			Resolution maxResolution = allResolutions [allResolutions.Length - 1];
			Screen.SetResolution (maxResolution.width, maxResolution.height, true);
		} else {
			SetScreenResolution (activeScreenResIndex);
		}
		PlayerPrefs.SetInt ("fullscreen", ((isFullscreen) ? 1 : 0));
		PlayerPrefs.Save ();
	}

	//	public void SetMasterVolume(float value) {
	//		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);
	//	}
	//
	//	public void SetMusicVolume(float value) {
	//		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);
	//	}
	//
	//	public void SetSFXVolume(float value) {
	//		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.SFX);
	//	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject selectCTopicHolder;

	public Slider[] volumeSliders;
	public Toggle[] resolutionToggles;
	public Toggle fullscreenToggle;
	public int[] screenWidths;
	int activeScreenResIndex;

	void Start(){
		activeScreenResIndex = PlayerPrefs.GetInt ("screen res index");
		bool isFullscreen = (PlayerPrefs.GetInt ("fullscreen") == 1) ? true : false;

		for (int i = 0; i < resolutionToggles.Length; i++) {
			resolutionToggles [i].isOn = i == activeScreenResIndex;
		}

		fullscreenToggle.isOn = isFullscreen; 
	}

	public void Play() {
//		SceneManager.LoadScene ("MalePrototype");	
		mainMenuHolder.SetActive (false);
		selectCTopicHolder.SetActive (true);
	}
		
	public void Quit() {
		Application.Quit ();
	}

	public void MainMenu() {
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
		selectCTopicHolder.SetActive (false);
	}

	public void OptionsMenu() {
		mainMenuHolder.SetActive (false);
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

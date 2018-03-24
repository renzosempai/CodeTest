using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public Image black;
	public Animator Anim;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Male Player") {
			StartCoroutine (Fading ());
		}
	}

	IEnumerator Fading(){
		Anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (levelToLoad);
	}
}

﻿using System.Collections;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	public void LoadScene(int level)
	{
		Application.LoadLevel (level);
	}

}

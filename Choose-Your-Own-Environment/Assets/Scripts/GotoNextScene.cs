using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoNextScene : MonoBehaviour {
	public float timeout;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Invoke ("LoadNextLevel", timeout);
	}

	private void LoadNextLevel() {
				SceneController.LoadNextLevel ();
	}
}

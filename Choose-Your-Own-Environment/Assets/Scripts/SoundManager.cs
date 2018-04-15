using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	AudioSource soundEffect;

	// Use this for initialization
	void Start () {
		soundEffect = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
	}

	public void Stop() {
		soundEffect.Stop ();
	}

	public void PlaySound(string soundName) {
		AudioClip NewClip = Resources.Load<AudioClip> ("Sound/" + soundName);

		if (NewClip == null) {
			Debug.Log ("doesn't exist! sound=" + soundName);
		}

		soundEffect.clip = NewClip;
		soundEffect.Play ();
	}
}

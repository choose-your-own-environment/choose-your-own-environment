using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	AudioSource backgroundMusic;
	[System.NonSerialized]
	bool startPlaying;
	[System.NonSerialized]
	string songName;

	// Use this for initialization
	void Start () {
		startPlaying = true;
		songName = "choose-1850";
		
		backgroundMusic = GetComponent<AudioSource> ();
		backgroundMusic.loop = true;

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		// check 
		if (songName != null && (startPlaying || !backgroundMusic.isPlaying)) {
			// song just ended, load new song name

			AudioClip NewClip = Resources.Load<AudioClip> ("Music/" + songName);

			if (NewClip == null) {
				Debug.Log ("doesn't exist! song=" + songName);
			}

			backgroundMusic.clip = NewClip;
			backgroundMusic.Play ();
			startPlaying = false;
		}
	}

	public void StopMusic() {
		
		backgroundMusic.loop = false;
		backgroundMusic.Stop ();
	}

	public void StartMusic() {

		startPlaying = true;
	}

	public void ChangeMusic(string SongName) {

		if (this.songName.Equals(SongName) && backgroundMusic.isPlaying) {
			return;
		}

		if (!backgroundMusic.isPlaying) {
			
			startPlaying = true;
			backgroundMusic.loop = true;
		} else {
			
			backgroundMusic.loop = false;
		}

		this.songName = SongName;
	}
}

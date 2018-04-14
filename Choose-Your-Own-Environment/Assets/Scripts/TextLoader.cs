using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour {
    public TextAsset textFile;
	// Use this for initialization
	void Start () {
        Text text = FindObjectOfType<Text>();
        text.text = textFile.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text leftCharacterText;
    public Text rightCharacterText;
    public Text narratorText;
    public Button promptButton;
    public List<Button> choiceList;


	// Use this for initialization
	void Start () {
		
	}
	
	public void LeftCharacterSpeaks(string speach)
    {
        leftCharacterText.text = speach;
    }

    public void RightCharacterSpeaks(string speach)
    {
        rightCharacterText.text = speach;
    }

    public void NarratorSpeaks(string speach)
    {
        narratorText.text = speach;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text leftCharacterText;
    public Text rightCharacterText;
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
}

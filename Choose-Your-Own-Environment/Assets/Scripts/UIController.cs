using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text leftCharacterText;
	public Image leftPortrait;
    public Text rightCharacterText;
	public Image rightPortrait;
    public Text narratorText;
    public Button promptButton;
    public List<Button> choiceList;

	// Use this for initialization
	void Start () {
		
	}

	public void Reset() {
		leftPortrait.enabled = false;
		rightPortrait.enabled = false;
		promptButton.enabled = false;
		foreach (Button button in choiceList) {
			button.enabled = false;
		}
	}
	
	public void LeftCharacterSpeaks(string speach)
    {
        leftCharacterText.text = speach;
		leftPortrait.enabled = true;
    }

    public void RightCharacterSpeaks(string speach)
    {
        rightCharacterText.text = speach;
		leftPortrait.enabled = true;
    }

    public void NarratorSpeaks(string speach)
    {
        narratorText.text = speach;
    }

	public void Prompt(string text) {
		promptButton.GetComponent<Text> ().text = text;
		promptButton.enabled = true;
	}

	public void Choices(List<string> choices) {
		for (int i = 0; i < choices.Count; i++) {
			choiceList [i].GetComponent<Text> ().text = choices [i];
			choiceList [i].enabled = true;
		}
	}

	public void OnPromptClick() {
		// TODO advance to next item
	}

	public void OnChoice(int i) {
		// TODO advance to next item & apply consequence
	}
}

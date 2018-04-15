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
		leftPortrait.gameObject.SetActive(false);
		rightPortrait.gameObject.SetActive(false);
		promptButton.gameObject.SetActive(false);
		foreach (Button button in choiceList) {
			button.gameObject.SetActive(false);
		}
		leftCharacterText.text = "";
		rightCharacterText.text = "";
		narratorText.text = "";
	}
	
	public void LeftCharacterSpeaks(string speach)
    {
        leftCharacterText.text = speach;
		leftPortrait.gameObject.SetActive(true);
    }

    public void RightCharacterSpeaks(string speach)
    {
        rightCharacterText.text = speach;
		leftPortrait.gameObject.SetActive(true);
    }

    public void NarratorSpeaks(string speach)
    {
        narratorText.text = speach;
    }

	public void Prompt(string text) {
		promptButton.GetComponentInChildren<Text> ().text = text;
		promptButton.gameObject.SetActive(true);
		promptButton.enabled = true;
	}

	public void Choices(List<string> choices) {
		for (int i = 0; i < choices.Count; i++) {
			choiceList [i].GetComponentInChildren<Text> ().text = choices [i];
			choiceList [i].gameObject.SetActive(true);
		}
	}

	public void OnPromptClick() {
		Debug.Log ("click prompt");
		Reset ();
		FindObjectOfType<GameController> ().advanceConversation = true;
	}

	public void OnChoice(int i) {
		Debug.Log ("click choice=" + i);
		Reset ();
		FindObjectOfType<GameController> ().advanceConversation = true;
	}
}

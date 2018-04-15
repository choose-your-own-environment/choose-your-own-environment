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
	public Image backgroundImage;
    public List<Button> choiceList;
	public List<string> choiceValues;

	// Use this for initialization
	void Start () {
		
	}

	public void Reset() {
		if (leftPortrait == null) {
			return;
		}
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
		rightPortrait.gameObject.SetActive(true);
    }

    public void NarratorSpeaks(string speach)
    {
        narratorText.text = speach;
    }

	public void Prompt(string text) {
		promptButton.GetComponentInChildren<Text> ().text = text;
		promptButton.gameObject.SetActive(true);
	}

	public void Background(string image) {
		backgroundImage.sprite = Resources.Load<Sprite> ("Background_images/" + image);
		backgroundImage.gameObject.SetActive (true);
	}

	public void Choices(Dictionary<string, string> choices) {
		int i = 0;
		foreach (KeyValuePair<string, string> entry in choices) {
			choiceList [i].GetComponentInChildren<Text> ().text = entry.Value;
			choiceList [i].gameObject.SetActive (true);
			choiceValues [i] = entry.Key;
			i++;
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
		FindObjectOfType<GameController> ().NextConversation (choiceValues[i]);
	}
}

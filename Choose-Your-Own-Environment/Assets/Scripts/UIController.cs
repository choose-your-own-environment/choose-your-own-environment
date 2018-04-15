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
	public List<string> choiceValues;
	public List<Image> namedImages;
	private Dictionary<string, Image> _images;

	// Use this for initialization
	void Start () {
		_images = new Dictionary<string, Image> ();
		foreach (Image img in namedImages) {
			_images.Add (img.name, img);
		}
	}

	void Update() {
		if (Input.GetKeyDown ("1")) {
			choiceList [0].onClick.Invoke ();
		} else if (Input.GetKeyDown ("2")) {
			choiceList [1].onClick.Invoke ();
		} else if (Input.GetKeyDown ("3")) {
			choiceList [2].onClick.Invoke ();
		} else if (Input.GetKeyDown ("4")) {
			choiceList [3].onClick.Invoke ();
		} else if (Input.GetKeyDown ("enter") || Input.GetKeyDown ("space")) {
			promptButton.onClick.Invoke ();
		}
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

	public void ChangeImages(Dictionary<string,string> imageSettings) {
		foreach (KeyValuePair<string, string> entry in imageSettings) {
			var img = _images [entry.Key] as Image;
			img.sprite = Resources.Load<Sprite> ("Images/" + entry.Value);
			img.gameObject.SetActive (true);
		}
	}

	public void HideImages(Dictionary<string, bool> hideImages) {
		foreach (KeyValuePair<string, bool> entry in hideImages) {
			var obj = _images [entry.Key];
			var img = obj.GetComponent<Image>();
			img.gameObject.SetActive (!entry.Value);
		}
	}

	public void Choices(Dictionary<string, string> choices) {
		List<string> keys = new List<string>(choices.Keys);
		keys.Sort ((a, b) => string.Compare(a, b));
		int i = 0;
		foreach (string key in keys) {
			choiceList [i].GetComponentInChildren<Text> ().text = "(" + (i + 1) + ") " + choices [key];
			choiceList [i].gameObject.SetActive (true);
			choiceValues [i] = key;
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

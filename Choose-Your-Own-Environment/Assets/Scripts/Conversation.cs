using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextLoader))]
public class Conversation : MonoBehaviour {
    public List<string> leftCharacter;
    public List<string> rightCharacter;
    private List<string> choices;
    public List<GameObject> consequence;
    TextLoader textLoader;
    GameObject myself;

	private AudioManager audioManager;
	private GameController gameController;

    // Use this for initialization
    void Start () {
        myself = gameObject;
        textLoader = GetComponent<TextLoader>();

        if (textLoader.dictionary.ContainsKey(leftCharacterKey))
        {
            leftCharacter = textLoader.dictionary[leftCharacterKey];
        }
        else
        {
            Debug.LogError("Left Character is missing");
        }
        if (textLoader.dictionary.ContainsKey(rightCharacterKey))
        {
            rightCharacter = textLoader.dictionary[rightCharacterKey];
        }
        else
        {
            Debug.LogError("Right Character is missing");
        }
        if (textLoader.dictionary.ContainsKey(choicesKey))
        {
            choices = textLoader.dictionary[choicesKey];
        }
        else
        {
            Debug.LogError("Choices are missing");
        }

		if (textLoader.dictionary.ContainsKey (musicKey))
		{
			Debug.Log("found music! song="+textLoader.dictionary [musicKey][0]);
			
			audioManager = FindObjectOfType<AudioManager> ();
			if (audioManager != null) {
				audioManager.ChangeMusic (textLoader.dictionary [musicKey] [0]);
			}
		}

		gameController = FindObjectOfType<GameController> ();
		if (gameController != null) {
			gameController.startConversation = true;
		}
    }

    public string GetNextLeftSpeach()
    {
        textLoader = GetComponent<TextLoader>();

        string returnval = string.Empty;
        if (leftCurrentIndex < leftCharacter.Count)
        {
            returnval = leftCharacter[leftCurrentIndex];
            leftCurrentIndex++;
        }
        return returnval;
    }

    public string GetNextRightSpeach()
    {
        string returnval = string.Empty;
        if (rightCurrentIndex < rightCharacter.Count)
        {
            returnval = rightCharacter[rightCurrentIndex];
            rightCurrentIndex++;
        }
        return returnval;
    }

    public void ResetConversation()
    {
        leftCurrentIndex = 0;
        rightCurrentIndex = 0;
    }


    public List<ChoiceConsequence> GetConsequences()
    {
        if (choices.Count != consequence.Count)
        {
            Debug.LogError("Choice to Consequence count mismatch!");
            throw new System.Exception("Choice to Consequence count mismatch!");
        }

        List<ChoiceConsequence> returnval = new List<ChoiceConsequence>();

        for (int currentChoice = 0; currentChoice < choices.Count; currentChoice++)
        {

            ChoiceConsequence currentConsequence = new ChoiceConsequence(choices[currentChoice], consequence[currentChoice]);
            returnval.Add(currentConsequence);
        }
        return returnval;
    }

    private int leftCurrentIndex = 0;
    private int rightCurrentIndex = 0;

    private const string leftCharacterKey = "leftcharacter";
    private const string rightCharacterKey = "rightcharacter";
    private const string choicesKey = "choice";
	private const string musicKey = "music";
}

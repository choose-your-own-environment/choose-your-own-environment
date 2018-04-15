using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(TextLoader))]
public class Conversation : MonoBehaviour {
    //public List<string> leftCharacter;
    //public List<string> rightCharacter;
	public Dictionary<string, StoryNode> script;
	public string nodeId;
    public List<string> choices;
    public List<GameObject> consequence;
    //TextLoader textLoader;
    ConversationLoader conversationLoader;

	private AudioManager audioManager;
	private GameController gameController;

    private int currentIndex = 0;
	private StoryNode currentNode;

    // Use this for initialization
    void Start () {
        
        //textLoader = GetComponent<TextLoader>();
        conversationLoader = GetComponent<ConversationLoader>();

        /*
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
        */

        choices = conversationLoader.choice;
        script = conversationLoader.script;

        if (conversationLoader.music.Count > 0)
		{
			Debug.Log("found music! song="+ conversationLoader.music[0]);
			
			audioManager = FindObjectOfType<AudioManager> ();
			if (audioManager != null) {
				audioManager.ChangeMusic (conversationLoader.music[0]);
			}
		}

		currentNode = script [nodeId];

		if (currentNode.stats != null) {
			gameController = FindObjectOfType<GameController> ();
			if (gameController != null) {
				gameController.gameProgress.UpdateStats (currentNode.stats);
			}
		}
    }

	public StoryLine GetNextLine()
    {
		if (currentNode == null || currentNode.dialog == null) {
			return null;
		}

		StoryLine returnval = null;
		if (currentIndex < currentNode.dialog.Count)
        {
			returnval = currentNode.dialog[currentIndex];
            currentIndex++;
        }
        return returnval;
    }

    /*
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
    */

    public void ResetConversation()
    {
        currentIndex = 0;
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

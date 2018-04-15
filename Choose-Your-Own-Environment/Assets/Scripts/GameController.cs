using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject currentConversation;
    public UIController ui;
    private Conversation convo;
	public PlayerStats gameProgress;
	public StoryLine currentLine;
	public bool advanceConversation = true;
    //public bool startConversation = false;

    // Use this for initialization
    void Start () {
        GameObject conversation = GameObject.FindGameObjectWithTag("Conversation");
        convo = conversation.GetComponentInChildren<Conversation>();
        currentConversation = convo.gameObject;

        if (SceneController.ActiveScene() == 0)
        {
            SceneController.LoadNextLevel();
        }
    }

	void Update() {

        if (SceneController.ActiveScene() == conversationIndex)
        {
			if (advanceConversation) {
				advanceConversation = false;

				DisplayNextLine ();
			}
        }
    }

	public void DisplayNextLine()
	{
		// call when in conversation
		convo = currentConversation.GetComponent<Conversation>();
		//consequences = convo.GetConsequences();

		currentLine = convo.GetNextLine();

		if (currentLine == null) {
			return;
		}

		switch (currentLine.GetType()) {
		case StoryLine.ScriptType.Narrator:
			{
				NarratorSpeaks ();
				break;
			}
		case StoryLine.ScriptType.LeftCharacter:
			{
				LeftCharacterSpeaks ();
				break;
			}
		case StoryLine.ScriptType.RightCharacter:
			{
				RightCharacterSpeaks ();
				break;
			}
		case StoryLine.ScriptType.Prompt:
			{
				DisplayPrompt();
				break;
			}
		case StoryLine.ScriptType.Choice:
			{
				DisplayChoices ();
				break;
			}
		case StoryLine.ScriptType.Background:
			{
				ChangeBackground();
				break;
			}
		case StoryLine.ScriptType.Music:
			{
				FindObjectOfType<MusicManager>().ChangeMusic(currentLine.music);
				advanceConversation = true;
				break;
			}
		case StoryLine.ScriptType.Sound:
			{
				FindObjectOfType<SoundManager>().PlaySound(currentLine.sound);
				advanceConversation = true;
				break;
			}
		case StoryLine.ScriptType.None:
			{
				Debug.Log ("empty node");
				advanceConversation = true;
				break;
			}
		}


	}

	private void NarratorSpeaks()
	{
		ui.NarratorSpeaks (currentLine.narrator);
		advanceConversation = true;
	}

    private void LeftCharacterSpeaks()
    {
		ui.LeftCharacterSpeaks(currentLine.leftcharacter);
		advanceConversation = true;
    }

    private void RightCharacterSpeaks()
    {
		ui.RightCharacterSpeaks(currentLine.rightcharacter);
		advanceConversation = true;
    }

    private void DisplayChoices()
    {
		ui.Choices (currentLine.choices);
    }

	private void DisplayPrompt()
	{
		ui.Prompt (currentLine.prompt);
	}

	private void ChangeBackground()
	{
		ui.Background (currentLine.background);
		advanceConversation = true;
	}

	public void NextConversation(string choice)
	{
		convo.LoadNextConversation (choice);
		advanceConversation = true;
	}

	public void NextScene()
	{
		Debug.Log ("Loading Next Scene");
		SceneController.LoadNextLevel ();
	}

	private string leftSpeach = string.Empty;
    private string rightSpeach = string.Empty;
    private List<ChoiceConsequence> consequences;

    public float speachDelay = 3.0f;

	private const int titleIndex = 1;
    private const int prologueIndex = 2;
    private const int conversationIndex = 3;
    private const int epilogueIndex = 4;
    private const int endIndex = 5;
}

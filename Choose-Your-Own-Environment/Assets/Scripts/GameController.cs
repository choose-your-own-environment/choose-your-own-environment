using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject currentConversation;
    public UIController ui;
    private Conversation convo;
	public PlayerStats gameProgress;
    public ScriptLine currentLine;
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
			DisplayChoices ();
			return;
		}

		switch (currentLine.type) {
		case ScriptLine.ScriptType.Narrator:
			{
				NarratorSpeaks ();
				break;
			}
		case ScriptLine.ScriptType.LeftCharacter:
			{
				LeftCharacterSpeaks ();
				break;
			}
		case ScriptLine.ScriptType.RightCharacter:
			{
				RightCharacterSpeaks ();
				break;
			}
		case ScriptLine.ScriptType.Prompt:
			{
				DisplayPrompt();
				break;
			}
		}


	}

	private void NarratorSpeaks()
	{
		ui.NarratorSpeaks (currentLine.value);
		advanceConversation = true;
	}

    private void LeftCharacterSpeaks()
    {
        ui.LeftCharacterSpeaks(currentLine.value);
		advanceConversation = true;
    }

    private void RightCharacterSpeaks()
    {
        ui.RightCharacterSpeaks(currentLine.value);
		advanceConversation = true;
    }

    private void DisplayChoices()
    {
		ui.Choices (convo.choices);
    }

	private void DisplayPrompt()
	{
		ui.Prompt (currentLine.value);
	}

	public void NextConversation(int choice)
	{
		// TODO fire consequence and load next text
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

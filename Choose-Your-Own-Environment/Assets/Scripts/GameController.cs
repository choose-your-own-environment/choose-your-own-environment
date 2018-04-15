using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject currentConversation;
    public UIController ui;
    private Conversation convo;
	public PlayerStats gameProgress;
	public bool startConversation = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		SceneController.LoadNextLevel ();
	}

	void Update() {

		if (startConversation) {

			startConversation = false;

			// call when in conversation
			convo = currentConversation.GetComponent<Conversation> ();
			consequences = convo.GetConsequences ();

			Invoke ("LeftCharacterSpeaks", speachDelay);
		}
	}

    private void LeftCharacterSpeaks()
    {
        leftSpeach = convo.GetNextLeftSpeach();
        
        
        if (leftSpeach.Equals(string.Empty))
        {
            Invoke("RightCharacterSpeaks", speachDelay);
        }
        else
        {
            ui.LeftCharacterSpeaks(leftSpeach);
            Invoke("LeftCharacterSpeaks", speachDelay);
        }

    }

    private void RightCharacterSpeaks()
    {
        rightSpeach = convo.GetNextRightSpeach();
        
       
        if (rightSpeach.Equals(string.Empty))
        {
            Invoke("DisplayChoices", speachDelay);
        }
        else
        {
            ui.RightCharacterSpeaks(rightSpeach);
            Invoke("RightCharacterSpeaks", speachDelay);
        }
    }

    private void DisplayChoices()
    {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject currentConversation;
    public UIController ui;
    private Conversation convo;

	// Use this for initialization
	void Start () {
        convo = currentConversation.GetComponent<Conversation>();
        //consequences = convo.GetConsequences();
      
        Invoke("LeftCharacterSpeaks", speachDelay);
	}

    private void LeftCharacterSpeaks()
    {
        leftSpeach = convo.GetNextLeftSpeach();
        ui.LeftCharacterSpeaks(leftSpeach);
        
        if (leftSpeach.Equals(string.Empty))
        {
            Invoke("RightCharacterSpeaks", speachDelay);
        }

    }

    private void RightCharacterSpeaks()
    {
        rightSpeach = convo.GetNextRightSpeach();
        ui.RightCharacterSpeaks(rightSpeach);
       
        if (rightSpeach.Equals(string.Empty))
        {
            Invoke("DisplayChoices", speachDelay);
        }
    }

    private void DisplayChoices()
    {

    }

    private string leftSpeach = string.Empty;
    private string rightSpeach = string.Empty;
    private List<ChoiceConsequence> consequences;

    public float speachDelay = 10.0f;

    private const int titleIndex = 0;
    private const int prologueIndex = 1;
    private const int conversationIndex = 2;
    private const int epilogueIndex = 3;
    private const int endIndex = 4;
}

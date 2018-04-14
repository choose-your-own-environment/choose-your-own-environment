using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextLoader))]
public class Conversation : MonoBehaviour {
    public List<string> leftCharacter;
    public List<string> rightCharacter;
    private List<string> choices;
    public List<GameObject> consequence;


    // Use this for initialization
    void Awake () {
        TextLoader textLoader = GetComponent<TextLoader>();

        if (textLoader.dictionary.ContainsKey(leftCharacterKey))
        {
            leftCharacter = textLoader.dictionary[leftCharacterKey];
            Debug.Log("left count " + leftCharacter.Count);
        }
        else
        {
            Debug.LogError("Left Character is missing");
        }
        if (textLoader.dictionary.ContainsKey(rightCharacterKey))
        {
            rightCharacter = textLoader.dictionary[rightCharacterKey];
            Debug.Log("right count " + rightCharacter.Count);
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

    }

    public string GetNextLeftSpeach()
    {
        string returnval = string.Empty;
        Debug.Log("get speach left" + leftCharacter.Count);
        if (leftCurrentIndex < leftCharacter.Count)
        {
            returnval = leftCharacter[leftCurrentIndex];
            Debug.Log("here");
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
}

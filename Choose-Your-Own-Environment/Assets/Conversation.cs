using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextLoader))]
public class Conversation : MonoBehaviour {
    private List<string> leftCharacter;
    private List<string> rightCharacter;
    private List<string> choices;
    public List<GameObject> consequence;


    // Use this for initialization
    void Start () {
        TextLoader textLoader = GetComponent<TextLoader>();

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

    }

    // Update is called once per frame
    void Update () {
		
	}

    private const string leftCharacterKey = "leftcharacter";
    private const string rightCharacterKey = "rightcharacter";
    private const string choicesKey = "choice";
}

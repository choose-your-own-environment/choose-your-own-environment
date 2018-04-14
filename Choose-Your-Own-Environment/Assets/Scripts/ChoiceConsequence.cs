using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceConsequence {
    public string choice;
    public GameObject consequence;

    public ChoiceConsequence(string _choice, GameObject _consequence)
    {
        choice = _choice;
        consequence = _consequence;
    }
	
}

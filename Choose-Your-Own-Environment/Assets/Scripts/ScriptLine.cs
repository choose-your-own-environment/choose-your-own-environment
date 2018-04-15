using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLine {
    public enum ScriptType { Narrator, LeftCharacter, RightCharacter, Prompt, Choice};

    public ScriptType type;
    public string value;

    public ScriptLine(ScriptType _type, string _value)
    {
        type = _type;
        value = _value;
    }
}

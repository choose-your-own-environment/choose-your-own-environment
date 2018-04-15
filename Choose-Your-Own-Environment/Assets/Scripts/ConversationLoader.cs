using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ConversationLoader : MonoBehaviour {
    public List<string> music;
    public List<string> choice;
    public List<ScriptLine> script;

    

    private const string delimiter = ">:";
    private const string musicKeyName = "music";
    private const string leftKeyName = "leftcharacter";
    private const string rightKeyName = "rightcharacter";
    private const string narratorKeyName = "narrator";
    private const string promptKeyName = "prompt";
    private const string choiceKeyName = "choice";

    

    public TextAsset SourceText;
    // Use this for initialization
    void Awake()
    {
        script = new List<ScriptLine>();
        choice = new List<string>();
        music = new List<string>();
        
        
        ParseText(SourceText);
    }

    private static string NormalizeDiacriticalCharacters(byte[] bytes)
    {
        string value = System.Text.Encoding.Default.GetString(bytes);
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

		// TODO character replacements

		return value;
    }

    private void ParseText(TextAsset text)
    {
        string input = NormalizeDiacriticalCharacters(text.bytes);

        Debug.Log(input.Length);
        using (StringReader sr = new StringReader(input))
        {
            string line = string.Empty;
            int delimLocation = -1;
            string currentKey = string.Empty;
            string currentVal = string.Empty;
            do
            {
                line = sr.ReadLine();

                if (line != null && line.Contains(delimiter))
                {
                    if (currentKey != string.Empty)
                    {
                        AddValue(currentKey, currentVal);

                        currentKey = string.Empty;
                        currentVal = string.Empty;
                    }

                    delimLocation = line.IndexOf(delimiter);

                    currentKey = line.Substring(0, delimLocation);
                    currentVal = line.Substring(delimLocation + delimiter.Length);


                }
                else
                {
                    currentVal = string.Concat(currentVal, Environment.NewLine, line);
                }

            } while (line != null);
            AddValue(currentKey, currentVal);

        }


    }

    private void AddValue(string key, string val)
    {
        key = key.ToLower();

        ScriptLine.ScriptType type;

        switch (key)
        {
            case musicKeyName:
                {
                    music.Add(val);
                    return;
                }
            case choiceKeyName:
                {
                    choice.Add(val);
                    return;
                }
            case leftKeyName:
                {
                    type = ScriptLine.ScriptType.LeftCharacter;
                    break;
                }
            case rightKeyName:
                {
                    type = ScriptLine.ScriptType.RightCharacter;
                    break;
                }
            case narratorKeyName:
                {
                    type = ScriptLine.ScriptType.Narrator;
                    break;
                }
            case promptKeyName:
                {
                    type = ScriptLine.ScriptType.Prompt;
                    break;
                }            
             default:
                {
                    return;
                }
        }

        script.Add(new ScriptLine(type, val));
    }


    
}

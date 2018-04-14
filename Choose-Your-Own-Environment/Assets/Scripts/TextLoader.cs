using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour {
    public TextAsset SourceText;
	// Use this for initialization
	void Awake () {

        dictionary = new Dictionary<string, List<string>>();

        ParseText(SourceText.text);
	}

    private void ParseText(string input)
    {
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
                        Debug.Log(currentKey);
                        Debug.Log(currentVal);

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
            Debug.Log(currentKey);
            Debug.Log(currentVal);
        }

        
    }

    private void AddValue(string key, string val)
    {
        key = key.ToLower();
        if (dictionary.ContainsKey(key))
        {
            dictionary[key].Add(val);
        }
        else
        {
            List<string> newList = new List<string>();
            newList.Add(val);
            dictionary.Add(key, newList);
        }
    }


    public Dictionary<string, List<string>> dictionary;

    string delimiter = ">:";
}

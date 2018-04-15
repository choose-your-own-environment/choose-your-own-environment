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
                        //Debug.Log(currentKey);
                        //Debug.Log(currentVal);
                        
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
            //Debug.Log(currentKey);
            //Debug.Log(currentVal);
        }

        
    }

    private void AddValue(string key, string val)
    {
        key = key.ToLower();
		val = val.Trim ();
        if (dictionary.ContainsKey(key))
        {
            Debug.Log("key " + key + " val " + val);
            dictionary[key].Add(val);
        }
        else
        {
            Debug.Log("key " + key + " val " + val);
            List<string> newList = new List<string>();
            newList.Add(val);
            dictionary.Add(key, newList);
        }
        Debug.Log("dictionary count: " + dictionary[key].Count);
    }


    public Dictionary<string, List<string>> dictionary;

    string delimiter = ">:";
}

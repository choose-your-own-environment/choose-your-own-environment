using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class ConversationLoader : MonoBehaviour {
    public List<string> music;
    public List<string> choice;

    private const string delimiter = ">:";
    private const string musicKeyName = "music";
    private const string leftKeyName = "leftcharacter";
    private const string rightKeyName = "rightcharacter";
    private const string narratorKeyName = "narrator";
    private const string promptKeyName = "prompt";
    private const string choiceKeyName = "choice";

    public List<TextAsset> SourceText;
	[System.NonSerialized]
	public Dictionary<string, StoryNode> script;

	// Use this for initialization
    void Awake()
    {
		script = FindObjectOfType<GameController> ().script;
		
        choice = new List<string>();
        music = new List<string>();
        
		foreach (TextAsset text in SourceText) {
			ParseYaml (text);
		}
    }

    private static string NormalizeToAscii(byte[] bytes)
    {
        string value = System.Text.Encoding.Default.GetString(bytes);
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

		// TODO character replacements

		return value;
    }

	private void ParseYaml(TextAsset text)
	{
		if (text == null) {
			return;
		}

		GameController gameController = FindObjectOfType<GameController> ();

		List<StoryNode> nodes = new List<StoryNode>();

		var input = new StringReader(NormalizeToAscii (text.bytes));

		var deserializer = new DeserializerBuilder()
			.WithNamingConvention(new CamelCaseNamingConvention())
			.IgnoreUnmatchedProperties()
			.Build();

		var parser = new Parser(input);

		// Consume the stream start event "manually"
		parser.Expect<StreamStart>();

		while (parser.Accept<DocumentStart>())
		{
			// Deserialize the document
			var doc = deserializer.Deserialize<StoryNode>(parser);

			if (doc != null) {
				gameController.script.Add (doc.id, doc);
			}
		}

		Debug.Log ("finished a parse");
	}
}

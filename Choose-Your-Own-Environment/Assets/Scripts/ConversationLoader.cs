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
	public Dictionary<string, StoryNode> script;

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
		script = new Dictionary<string, StoryNode> ();
        choice = new List<string>();
        music = new List<string>();
        
		ParseYaml (SourceText);
//        ParseText(SourceText);
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

			script.Add (doc.id, doc);
		}
	}
}

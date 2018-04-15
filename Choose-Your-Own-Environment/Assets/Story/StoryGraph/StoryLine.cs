using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLine : ScriptableObject {
	public enum ScriptType { Narrator, LeftCharacter, RightCharacter, Prompt, Choice, None};

	public string leftcharacter { get; set; }
	public string rightcharacter { get; set; }
	public string narrator { get; set; }
	public string prompt { get; set; }
	public Dictionary<string, string> choices { get; set; }

	public ScriptType GetType() {
		if (leftcharacter != null) {
			return ScriptType.LeftCharacter;
		}

		if (rightcharacter != null) {
			return ScriptType.RightCharacter;
		}

		if (narrator != null) {
			return ScriptType.Narrator;
		}

		if (prompt != null) {
			return ScriptType.Prompt;
		}

		if (choices != null) {
			return ScriptType.Choice;
		}

		return ScriptType.None;
	}
}

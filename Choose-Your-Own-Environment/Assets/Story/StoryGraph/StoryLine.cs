using System.Collections;
using System.Collections.Generic;

public class StoryLine {
	public enum ScriptType {
		Narrator,
		LeftCharacter,
		RightCharacter,
		Prompt,
		Choice,
		Background,
		Music,
		Sound,
		None
	};

	public string leftcharacter { get; set; }
	public string rightcharacter { get; set; }
	public string narrator { get; set; }
	public string prompt { get; set; }
	public Dictionary<string, string> choices { get; set; }
	public string background { get; set; }
	public string music { get; set; }
	public string sound { get; set; }

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

		if (background != null) {
			return ScriptType.Background;
		}

		if (music != null) {
			return ScriptType.Music;
		}

		if (sound != null) {
			return ScriptType.Sound;
		}

		return ScriptType.None;
	}
}

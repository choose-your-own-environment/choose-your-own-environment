using System.Collections;
using System.Collections.Generic;

/**
 * this should act like XML DOM / aka a Union Type
 */
public class StoryLine {
	public enum ScriptType {
		Narrator,
		LeftCharacter,
		RightCharacter,
		Prompt,
		Choice,
		Image,
		HideImage,
		Music,
		Sound,
		None
	};

	public string leftcharacter { get; set; }
	public string rightcharacter { get; set; }
	public string narrator { get; set; }
	public string prompt { get; set; }
	/**
	 * keys are story node id's
	 * values are dialog text
	 */
	public Dictionary<string, string> choices { get; set; }
	/**
	 * keys are game object names, a'la GameObject.Find
	 * values are Sprite names
	 */
	public Dictionary<string, string> image { get; set; }
	/**
	 * key are game object names
	 * values - true => deactivate
	 */
	public Dictionary<string, bool> hide { get; set; }
	public string music { get; set; }
	public string sound { get; set; }
	// TODO list of conditionals
	// auto-advance to specific scene (goto)
	// generic image-set

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

		if (image != null) {
			return ScriptType.Image;
		}

		if (hide != null) {
			return ScriptType.HideImage;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNode : ScriptableObject {
	public string id { get; set; }
	public StatChange stats { get; set; }
	public List<StoryLine> dialog { get; set; }
}

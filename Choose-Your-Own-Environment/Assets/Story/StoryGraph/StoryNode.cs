using System.Collections;
using System.Collections.Generic;

public class StoryNode {
	public string id { get; set; }
	public StatChange stats { get; set; }
	public List<StoryLine> dialog { get; set; }
}

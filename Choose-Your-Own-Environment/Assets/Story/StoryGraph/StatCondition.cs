using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCondition {
	public string wealth;
	public string carbon;
	public string population;
	public string prosperity;
	// andThen / orElse - idea for the future
//	public List<StoryLine> andThen;
//	public List<StoryLine> orElse;

	public bool Test(PlayerStats stats) {
		bool pass = true;

		if (wealth != null) {
			pass &= IsPassing (wealth, stats.Wealth);
		}

		if (carbon != null) {
			pass &= IsPassing (carbon, stats.FutureCarbon);
		}

		if (population != null) {
			pass &= IsPassing (population, stats.PresentPopulation);
		}

		if (prosperity != null) {
			pass &= IsPassing (prosperity, stats.PresentProsperity);
		}

		if (pass) {
			// andThen - execute list of story items, should probably bail right away.
			return true;
		} else {
			// orElse - execute list of story items, should probably go thru all in tail?
			return false;
		}
	}

	private bool IsPassing(string expression, double value) {
		double testVal = double.Parse(expression.Substring (1).Trim());

		switch (expression [0]) {
		case '<':
			return value < testVal;
		
		case '>':
			return value > testVal;
		
		case '=':
			return value == testVal;
		}

		Debug.Log ("unknown condition=" + expression);
		return false;
	}
}

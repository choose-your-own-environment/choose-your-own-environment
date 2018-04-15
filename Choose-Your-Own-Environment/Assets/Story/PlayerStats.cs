using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats1", menuName = "Data/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject {
	public double Wealth;
	public int FutureCarbon;
	public double PresentProsperity;
}

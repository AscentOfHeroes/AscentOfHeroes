using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	private static int curHp = 100;
	private static int maxHp = 100;
	
	private static int curExp = 0;
	private static int maxExp = 100;
	private static int level = 1;
	
	private static int intellect = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (curHp <= 0) {
			curHp = 0;
			Death();
		}
		if (curExp >= maxExp) {
			LevelUp();
		}
		
		// For testing
		if(Input.GetKeyDown("1")) {
			curHp--;
		}
		if(Input.GetKeyDown("2")) {
			curExp++;
		}
	}

	void Death () {
		
	}

	void LevelUp () {
		level++;
		curExp = 0;
		maxExp += maxExp/10 - level*intellect;
	}

	public int GetCurHp () {
		return curHp;
	}
	
	public int GetMaxHp () {
		return maxHp;
	}
	
	public int GetCurExp () {
		return curExp;
	}
	
	public int GetMaxExp () {
		return maxExp;
	}

	public int GetIntellect () {
		return intellect;
	}
}
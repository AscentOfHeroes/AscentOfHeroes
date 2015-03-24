using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	private static int curHp = 100;
	private static int maxHp = 100;
	
	private static int curExp = 0;
	private static int maxExp = 100;
	private static int level = 1;
	
	private static int intellect = 0;

	public Text levelText;

	// Use this for initialization
	void Start () {
		levelText.text = "Level " + level;
	}
	
	// Update is called once per frame
	void Update () {

		// For testing
		if(Input.GetKeyDown("5")) {
			Heal (10);
		}
		if(Input.GetKeyDown("6")) {
			GainExp(10);
		}

	}

	void Death () {
		
	}

	void LevelUp () {
		level++;
		curExp = 0;
		maxExp += maxExp/10 - level*intellect;
		levelText.text = "Level " + level;
	}

	// Public Modifiers
	public void Heal (int healAmount) {
		curHp = Mathf.Min(curHp + healAmount, maxHp);
	}
	public void TakeDamage (int damage) {
		curHp = Mathf.Max(curHp - damage, 0);
		if (curHp == 0) {
			Death ();
		}
	}
	public void GainExp (int exp) {
		curExp = Mathf.Min (curExp + exp, maxExp);
		if (curExp == maxExp) {
			LevelUp ();
		}
	}

	// Public Accessors
	public int GetCurHp () {return curHp;}
	public int GetMaxHp () {return maxHp;}
	public int GetCurExp () {return curExp;}
	public int GetMaxExp () {return maxExp;}
	public int GetIntellect () {return intellect;}
}

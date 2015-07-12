using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public static int aggroRange = 20;
	public float maxHp = 50;
	private float curHp;

	// Use this for initialization
	void Start () {
		curHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage (int damage) {
		curHp = Mathf.Max(curHp - damage, 0);
		if (curHp == 0) {
			Death ();
		}
	}

	void Death () {
		Destroy(gameObject);
	}
}

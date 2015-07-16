using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	public float timeToAttack = 1.0f;

	private PlayerStats player;
	private float? attackTimestamp;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		attackTimestamp = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimestamp != null && Time.time - attackTimestamp >= 2*timeToAttack) {
			attackTimestamp = null;
		}
	}

	public void Attack () {
		if (attackTimestamp == null) {
			attackTimestamp = Time.time;
		}
		else if (Time.time - attackTimestamp >= timeToAttack) {
			player.TakeDamage(5);
			attackTimestamp = Time.time;
		}
	}

	public void StopAttack () {
		if (attackTimestamp != null) {
			attackTimestamp = null;
		}
	}
}

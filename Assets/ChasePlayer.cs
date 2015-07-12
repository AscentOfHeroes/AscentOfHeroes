using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	private PlayerStats player;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPosition = player.transform.position;
		if (Vector3.Distance(transform.position, playerPosition) < EnemyStats.aggroRange) {
			agent.SetDestination(playerPosition);
			if (Vector3.Distance(agent.transform.position, agent.destination) <= agent.stoppingDistance) {
				agent.transform.LookAt(new Vector3(playerPosition.x, agent.transform.position.y, playerPosition.z));
				if (gameObject.GetComponent<AttackPlayer>()) {
					gameObject.GetComponent<AttackPlayer>().Attack();
				}
			}
		}
	}
}

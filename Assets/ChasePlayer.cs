using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	public Vector3 playerPosition;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		if (Vector3.Distance(transform.position, playerPosition) < EnemyStats.aggroRange) {
			agent.SetDestination(playerPosition);
			if (Vector3.Distance(agent.transform.position, agent.destination) <= agent.stoppingDistance) {
				agent.transform.LookAt(new Vector3(playerPosition.x, agent.transform.position.y, playerPosition.z));
			}
		}
	}
}

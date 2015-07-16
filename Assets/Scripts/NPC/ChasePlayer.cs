using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

	public FieldOfVision fov;

	// How close the player must be before starting chase
	public int chaseProximity;

	// The distance for the character to chase the player
	public float chaseDistance;
	
	private PlayerStats player;
	private NavMeshAgent agent;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		agent = GetComponent<NavMeshAgent>();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// If we see the player, chase
		if (fov.playerInSight) {
			// If too far from start position, return to start position
			if (ReachedChaseLimit()) {
				agent.SetDestination(startPosition);
			}

			// If player is close enough, chase the player
			else if (InChaseProximity()) {
				agent.SetDestination(player.transform.position);

				// If player is close enough, face and interact with the player
				if (ReachedInteractionProximity()) {
					FacePlayer();
					InteractWithPlayer();
				}
			}
		}
		// If we don't see the player and we aren't at the start position, return to start
		else if (AwayFromDefaultPosition()) {
			agent.SetDestination(startPosition);
		}
	}

	bool ReachedChaseLimit () {
		return Vector3.Distance(transform.position, startPosition) > chaseDistance;
	}

	bool InChaseProximity() {
		return Vector3.Distance(transform.position, player.transform.position) < chaseProximity;
	}

	bool ReachedInteractionProximity () {
		return Vector3.Distance(agent.transform.position, agent.destination) <= agent.stoppingDistance;
	}

	bool AwayFromDefaultPosition () {
		return transform.position != startPosition;
	}

	// Make the character's body face the player (head is controlled by different script)
	void FacePlayer () {
		agent.transform.LookAt(new Vector3(player.transform.position.x, agent.transform.position.y, player.transform.position.z));
	}

	void InteractWithPlayer () {
		// If this is an enemy that can attack, attack the player
		if (gameObject.GetComponent<AttackPlayer>()) {
			gameObject.GetComponent<AttackPlayer>().Attack();
		}

		// TODO: Add other kinds of interactions (e.g., talk to, animate, etc.).
	}
}

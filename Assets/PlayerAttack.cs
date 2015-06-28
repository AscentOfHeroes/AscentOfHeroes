using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.Mouse0) ) {
			EquipWeapon.equipSpot.Translate(0,0,1);
			AttackEnemy();
		}
		else if (Input.GetKeyUp(KeyCode.Mouse0)) {
			EquipWeapon.equipSpot.Translate(0,0,-1);
		}
	}

	void AttackEnemy () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3)) {
			if (hit.collider.gameObject.tag == "Enemy") {
				hit.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(10);
			} else if (hit.collider.transform.parent.tag == "Enemy") {
				hit.collider.transform.parent.gameObject.GetComponent<EnemyStats>().TakeDamage(10);
			}
		}
	}
}

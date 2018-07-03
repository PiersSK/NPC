using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {
	private GameObject playerObj;

	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Attack();
	}

	private void Attack() {
		if(Input.GetKeyDown(KeyCode.F)) {
			PlayerMobility player = playerObj.GetComponent<PlayerMobility>();
			player.attackCount = 0.5f;
		}
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Enemy") {
			// Destroy(col.gameObject);
			EnemyMobility enemy = col.gameObject.GetComponent<EnemyMobility>();

			enemy.knockbackDirection = GetKnockbackDirection(col.gameObject);
			enemy.knockbackCount = 0.2f;
			enemy.health -= 1;
		}
	}

	private Vector2 GetKnockbackDirection(GameObject enemy) {
		return (enemy.transform.position - transform.position) / Vector3.Distance(transform.position, enemy.transform.position);
	}
}

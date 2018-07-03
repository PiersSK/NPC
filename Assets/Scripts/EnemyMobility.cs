using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour {
	public GameObject player;
	public float enemyAggroRange;
	public float enemySpeed;
    public Vector2 knockbackDirection;
	public float knockbackMultiplier;
    public float knockbackCount;
	public int health;

	private Vector3 playerPosition;
	private Vector3 enemyPosition;
	private Vector3 movementDirection;

	private SpriteRenderer enemySprite;
	private Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
		enemyRB = gameObject.GetComponent<Rigidbody2D>();
		enemySprite = gameObject.GetComponent<SpriteRenderer>();
		UpdatePositions();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(health == 0) {
			Destroy(gameObject);
		}

		UpdatePositions();
		float distanceToPlayer = GetDistanceToPlayer();

		if(knockbackCount <= 0) {
			enemySprite.color = new Color(255, 255, 255);
			if(distanceToPlayer <= enemyAggroRange) {
				movementDirection = (playerPosition - enemyPosition) / distanceToPlayer;
				enemyRB.velocity = movementDirection * enemySpeed;
			}
		} else {
			enemySprite.color = new Color(255, 0, 0);
			enemyRB.velocity = knockbackDirection * knockbackMultiplier;
            knockbackCount -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "Player") {
			float distanceToPlayer = GetDistanceToPlayer();
			movementDirection = (playerPosition - enemyPosition) / distanceToPlayer;

			var playerController = player.GetComponent<PlayerMobility>();

			if(!playerController.isInvincible) {
				PlayerHealth.health -= 1;

				playerController.knockbackDirection = movementDirection;
				playerController.knockbackCount = 0.2f;
			}
			
		}
	}
		
	private float GetDistanceToPlayer() {
		return Vector3.Distance(playerPosition, enemyPosition);
	}

	private void UpdatePositions() {
		enemyPosition = gameObject.transform.position;
		playerPosition = player.transform.position;
	}

}

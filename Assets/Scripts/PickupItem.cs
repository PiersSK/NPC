using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {
	public float pickupRange;
	private RaycastHit2D[] results;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInteraction();
	}

	void CheckForInteraction() {
		if(Input.GetKeyDown(KeyCode.E)) {
			Vector2 playerDirection = PlayerMobility.GetPlayerDirection();
			Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);

			RaycastHit2D hit = Physics2D.Raycast(playerPosition, playerDirection, pickupRange);
			Debug.DrawLine(playerPosition, playerDirection, Color.red, 2);;
			if (hit.collider != null) {
					Debug.Log("Hit wasn't null - " + hit.collider.name);
					if (hit.collider.tag == "Item") Destroy(hit.collider.gameObject);
			}
			if(hit.collider == null) {
				Debug.Log("We messed up");
			}
		}
    }
}

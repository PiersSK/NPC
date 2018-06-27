using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
	public float pickupRange;
	private RaycastHit2D[] results;
	private Collider2D playerCollider;

	// Use this for initialization
	void Start () {
		playerCollider = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInteraction();
	}

	void CheckForInteraction() {
		if(Input.GetKeyDown(KeyCode.E)) {
			Vector2 playerDirection = PlayerMobility.GetPlayerDirection();
			Vector2 playerPosition = new Vector2(
				transform.position.x + playerCollider.offset.x,
				transform.position.y + playerCollider.offset.y
			);

			RaycastHit2D hit = Physics2D.Raycast(playerPosition, playerDirection, pickupRange);

			if (hit.collider != null) {
				string colliderTag = hit.collider.tag;
				switch (colliderTag) {
					case "Item":
						PickupItem(hit.collider.gameObject);
						break;
					case "Water":
						PlayerSurf(hit.collider.gameObject, playerDirection);
						break;
					default:
						Debug.Log("Collider has no Interaction options");
						break;
				}
			}
		}
    }

	void PickupItem(GameObject itemObj) {
		ItemIdentifier item = itemObj.GetComponent<ItemIdentifier>();

		bool itemObtained = PlayerInventory.AddItemToInventory(item.itemName);
		if(itemObtained) Destroy(itemObj);
	}

	void PlayerSurf(GameObject water, Vector2 playerDirection) {
		List<string> inventory = PlayerInventory.GetPlayerInventory();

		if(inventory.Contains("Surf")) {
			transform.position += new Vector3(playerDirection.x, playerDirection.y, 0);
		}
	}
}

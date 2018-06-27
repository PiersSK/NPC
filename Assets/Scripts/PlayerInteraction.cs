using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour {
	public float pickupRange;
	public Text infoText;

	private RaycastHit2D[] results;
	private Collider2D playerCollider;

	private float textTime;

	// Use this for initialization
	void Start () {
		playerCollider = gameObject.GetComponent<Collider2D>();
		textTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForInteraction();
		ClearText();
	}

	void ClearText() {
		if (Time.time > textTime + 5f) {
			GameObject infoTextObject = GameObject.Find("InfoText");
			Text infoText = infoTextObject.GetComponent <Text> ();
			infoText.text = "";
		}
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
						PlayerSurf(playerDirection);
						break;
					case "Sign":
						ReadSign(hit.collider.gameObject);
						break;
					case "Person":
						TalkToPerson(hit.collider.gameObject);
						break;
					default:
						Debug.Log("Collider has no Interaction options");
						break;
				}
			}
		}
    }

	void ReadSign(GameObject sign) {
		string signText = sign.GetComponent	<Sign> ().GetSignText();
		GameObject infoTextObject = GameObject.Find("InfoText");
		Text infoText = infoTextObject.GetComponent <Text> ();

		infoText.text = signText;

		textTime = Time.time;

	}

	void TalkToPerson(GameObject person) {

	}

	void PickupItem(GameObject itemObj) {
		ItemIdentifier item = itemObj.GetComponent<ItemIdentifier>();

		bool itemObtained = PlayerInventory.AddItemToInventory(item.itemName);
		if(itemObtained) {
			Destroy(itemObj);
			infoText.text = "Obtained item: " + item.itemName;
		} else {
			infoText.text = "Inventory is full!";			
		}
	}

	void PlayerSurf(Vector2 playerDirection) {
		List<string> inventory = PlayerInventory.GetPlayerInventory();

		if(inventory.Contains("Surf")) {
			transform.position += new Vector3(playerDirection.x, playerDirection.y, 0);
		}
	}
}

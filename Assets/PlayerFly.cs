using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour {
	private bool flyingEnabled;
	private List<string> inventory;
	private Collider2D playerCollider;

	// Use this for initialization
	void Start () {
		inventory = PlayerInventory.GetPlayerInventory();
		playerCollider = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		flyingEnabled = inventory.Contains("Fly") ? true : false;

		if(Input.GetKeyDown(KeyCode.F) && flyingEnabled) {
			Debug.Log("Flying! collider.enabled set to " + !playerCollider.enabled);
			playerCollider.enabled = !playerCollider.enabled;
		}
	}
}

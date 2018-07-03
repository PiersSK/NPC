using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdentifier : MonoBehaviour {
	public string itemName;
	// private GameObject player;

	// Use this for initialization
	void Start () {
		// player = GameObject.Find("Player");
		List<string> inventory = PlayerInventory.GetPlayerInventory();
		if(inventory.Contains(itemName)) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

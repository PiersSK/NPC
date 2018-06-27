﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	public static List<string> inventoryItems = new List<string>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static bool AddItemToInventory(string item) {
		Debug.Log(item);
		if(inventoryItems.Count < 2) {
			inventoryItems.Add(item);
			return true;
		} else {
			Debug.Log("Sorry, inventory is full");
			return false;
		}
	}

	public static List<string> GetPlayerInventory() {
		return inventoryItems;
	}
}

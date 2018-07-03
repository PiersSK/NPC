using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtainedItemIndicator : MonoBehaviour {
	public string itemName;
	public Sprite itemObtainedSprite;

	private Image indicatorImage;
	
	// Use this for initialization
	void Start () {
		indicatorImage = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		List<string> inventory = PlayerInventory.GetPlayerInventory();
		if(inventory.Contains(itemName)){
			indicatorImage.sprite = itemObtainedSprite;
		}
	}
}

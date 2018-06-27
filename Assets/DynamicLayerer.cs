using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLayerer : MonoBehaviour {
	public GameObject player;

	private SpriteRenderer envRenderer;

	// Use this for initialization
	void Start () {
		envRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > player.transform.position.y) {
			envRenderer.sortingOrder = 1;
		} else {
			envRenderer.sortingOrder = 3;
		}
	}
}

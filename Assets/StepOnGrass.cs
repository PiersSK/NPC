using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnGrass : MonoBehaviour {

	public Sprite grassNormal;
	public Sprite grassSteppedOn;
	public GameObject player;

    private SpriteRenderer grassRenderer;
	
	// Use this for initialization
	void Start () {
        grassRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
    void OnTriggerStay2D() {
		grassRenderer.sprite = grassSteppedOn;
		if(transform.position.y < (player.transform.position.y - 0.15f)) {
			grassRenderer.sortingOrder = 3;
		} else {
			grassRenderer.sortingOrder = 1;
		}
    }

	void OnTriggerExit2D() {
		Debug.Log("player leaves");
		grassRenderer.sprite = grassNormal;
		grassRenderer.sortingOrder = 1;
    }
}

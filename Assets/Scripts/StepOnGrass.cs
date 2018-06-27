using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		CheckForBattle();
    }

	void OnTriggerExit2D() {
		grassRenderer.sprite = grassNormal;
		grassRenderer.sortingOrder = 1;
    }

	void CheckForBattle() {
		float battleCheck = Random.Range(0.0f, 400.0f);
		if(battleCheck < 1) {
			PlayerPrefs.SetFloat("spawnX", transform.position.x);
        	PlayerPrefs.SetFloat("spawnY", transform.position.y);
			ChooseEncounter();
			SceneManager.LoadScene("Battle");
		}
	}

	void ChooseEncounter() {
		int pokemon = Random.Range(1, 4);
		switch (pokemon)
		{
			case 1:
				PlayerPrefs.SetString("enemy", "Pikachu");
				break;
			case 2:
				PlayerPrefs.SetString("enemy", "Mew");
				break;
			case 3:
				PlayerPrefs.SetString("enemy", "Ganon");
				break;
			default:
				Debug.Log("RNGesus h8s u");
				break;
		}
	}
}

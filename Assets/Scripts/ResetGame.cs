using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetOnDeath() {

		PlayerHealth.health = 6;
		PlayerInventory.inventoryItems = new List<string>();

		PlayerPrefs.SetFloat("spawnX", 0.0f);
		PlayerPrefs.SetFloat("spawnY", 0.0f);
		SceneManager.LoadScene("Safari");;

		Time.timeScale = 1.0f;

	}
}

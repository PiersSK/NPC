using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveBuilding : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.name == "Player") {
			PlayerPrefs.SetInt("returningFromScene", 1);
			PlayerPrefs.SetFloat("spawnX", 12.5f);
			PlayerPrefs.SetFloat("spawnY", 8.3f);
			SceneManager.LoadScene("Safari");
		}
	}
}

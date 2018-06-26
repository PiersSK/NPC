using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveBuilding : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.name == "Player") {
			PlayerPrefs.SetInt("returningFromRoom", 1);
			SceneManager.LoadScene("Safari");
		}
	}
}

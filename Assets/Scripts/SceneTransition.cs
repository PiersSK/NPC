using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
	public string sceneName;
	public Vector3 spawnPoint;

	void OnTriggerEnter2D (Collider2D col) {

		SetSpawnPoint();

		if(col.gameObject.name == "Player") {
			SceneManager.LoadScene(sceneName);
		}
		
	}

	void SetSpawnPoint() {
		PlayerPrefs.SetFloat("spawnX", spawnPoint.x);
		PlayerPrefs.SetFloat("spawnY", spawnPoint.y);
		PlayerPrefs.SetFloat("spawnZ", spawnPoint.z);
	}
}

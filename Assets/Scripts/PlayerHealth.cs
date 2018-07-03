using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public static int health;
	public GameObject resetGame;

	// Use this for initialization
	void Start () {
		health = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if( health == 0 ) {
			Time.timeScale = 0.0f;
			resetGame.SetActive(true);
		}
	}
}

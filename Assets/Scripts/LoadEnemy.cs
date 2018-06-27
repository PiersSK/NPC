using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemy : MonoBehaviour {
	public Sprite pikachu;
	public Sprite mew;
	public Sprite ganon;

	private SpriteRenderer pokemonRenderer;
	private string pokemon;

	// Use this for initialization
	void Start () {
		pokemonRenderer = gameObject.GetComponent<SpriteRenderer>();
		pokemon = PlayerPrefs.GetString("enemy");

		Dictionary<string, Sprite> pokemonSprites = new Dictionary<string, Sprite>(){
			{"Pikachu", pikachu},
			{"Mew", mew},
			{"Ganon", ganon}
		};

		Debug.Log(pokemon);
		Debug.Log(pokemonSprites);

		pokemonRenderer.sprite = pokemonSprites[pokemon];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

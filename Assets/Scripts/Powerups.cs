using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {
	public bool doublepoint;
	public bool safeMode;
	public float powerupLenght;
	private PowerupManager thePowerupManager;
	public Sprite[] PowerupSprites;
	// Use this for initialization
	void Start () {
		thePowerupManager = FindObjectOfType<PowerupManager>();
	}

	void Awake(){
		int powerupSelector = Random.Range(0, 2);
		switch(powerupSelector){
			case 0:
			doublepoint = true;
			break;

			case 1:
			safeMode = true;
			break;
		}
		GetComponent<SpriteRenderer>().sprite = PowerupSprites[powerupSelector];
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			thePowerupManager.ActivatePowerup(doublepoint, safeMode, powerupLenght);
		}
		gameObject.SetActive(false);
	}
}

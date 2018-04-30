using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {
	private bool doublepoint;
	private bool safeMode;
	private bool powerupActive;
	private float powerupLenghtCounter;

	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;
	private GameManager theGameManager;
	private float normalPointsPerSecond;
	private float UrchinRate;
	private PlatformDestroyer[] UrchinList;
	
	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
		theGameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(powerupActive){
			powerupLenghtCounter -= Time.deltaTime;

			if(theGameManager.powerupReset){
				powerupLenghtCounter = 0;
				theGameManager.powerupReset = false;
			}

			if(doublepoint){
				theScoreManager.pointPerSecond = normalPointsPerSecond * 2.75f;
				theScoreManager.shouldDouble = true;
			}

			if(safeMode){
				thePlatformGenerator.randomUrchinThreshold = 0f;
			}

			if(powerupLenghtCounter <= 0){
				theScoreManager.pointPerSecond = normalPointsPerSecond;
				thePlatformGenerator.randomUrchinThreshold = UrchinRate;
				theScoreManager.shouldDouble = false;

				powerupActive = false;
			}
		}
	}

	public void ActivatePowerup(bool points, bool safe, float time){
		doublepoint = points;
		safeMode = safe;
		powerupLenghtCounter = time;
		normalPointsPerSecond = theScoreManager.pointPerSecond;
		UrchinRate = thePlatformGenerator.randomUrchinThreshold;
		if(safeMode){
			UrchinList = FindObjectsOfType<PlatformDestroyer>();
			for(int i=0; i < UrchinList.Length; i++){
				if(UrchinList[i].gameObject.name.Contains("urchin")){
					UrchinList[i].gameObject.SetActive(false);
				}
			}
		}

		powerupActive = true;
	}
}

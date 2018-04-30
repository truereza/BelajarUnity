using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform platformGenerator;
	public Transform platformGenerator2;
	private Vector3 platformStartPoint;
	private Vector3 platformStartPoint2;
	public PlayerController thePlayer;
	private Vector3 playerStartPoint;
	private PlatformDestroyer[] platformList;
	private ScoreManager theScoreManager;
	public DeathMenu deathScreen;
	public bool powerupReset;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		platformStartPoint2 = platformGenerator2.position;
		playerStartPoint = thePlayer.transform.position;
		theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		deathScreen.gameObject.SetActive(true);
		// StartCoroutine("RestartGameCo");
	}

	public void Reset(){
		deathScreen.gameObject.SetActive(false);
		platformList = FindObjectsOfType<PlatformDestroyer>();
		for(int i=0; i < platformList.Length; i++){
			platformList[i].gameObject.SetActive(false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		platformGenerator2.position = platformStartPoint2;
		thePlayer.gameObject.SetActive(true);

		theScoreManager.ScoreCount = 0;
		theScoreManager.scoreIncreasing = true;

		powerupReset = true;
	}

	// public IEnumerator RestartGameCo(){
	// 	theScoreManager.scoreIncreasing = true;
	// 	thePlayer.gameObject.SetActive(false);
	// 	yield return new WaitForSeconds(0.5f);
	// 	platformList = FindObjectsOfType<PlatformDestroyer>();
	// 	thePlayer.transform.position = playerStartPoint;
	// 	platformGenerator.position = platformStartPoint;
	// 	platformGenerator2.position = platformStartPoint;
	// 	thePlayer.gameObject.SetActive(true);

	// 	theScoreManager.ScoreCount = 0;
	// 	theScoreManager.scoreIncreasing = true;
	// }
}

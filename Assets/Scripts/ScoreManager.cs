using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public Text ScoreText;
	public Text hiScoreText;
	public float ScoreCount;
	public float hiScoreTextCount;
	public float pointPerSecond;
	public bool scoreIncreasing;
	public bool shouldDouble;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore")){
			hiScoreTextCount = PlayerPrefs.GetFloat("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(scoreIncreasing){
			ScoreCount += pointPerSecond * Time.deltaTime;	
		}

		if(ScoreCount > hiScoreTextCount){
			hiScoreTextCount = ScoreCount;
			PlayerPrefs.SetFloat("HighScore", hiScoreTextCount);
		}

		ScoreText.text = "Score: " + Mathf.Round(ScoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round(hiScoreTextCount);
	}

	public void AddScore(int pointsToAdd){
		if(shouldDouble){
			pointsToAdd = pointsToAdd * 2;
		}
		ScoreCount += pointsToAdd;
	}
}

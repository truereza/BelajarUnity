using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
		public string gamePlayLevel;
	public void PlayGame(){
		Application.LoadLevel(gamePlayLevel);
	}
	public void QuitGame(){
		Application.Quit();
	}
}

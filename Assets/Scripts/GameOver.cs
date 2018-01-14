using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour {
	private GameObject winText;
	private GameObject loseText;
	private GameObject restart;
	private GameObject quit;
	void Start () {
		winText = GameObject.Find ("WinText");
		loseText = GameObject.Find ("LoseText");
		restart = GameObject.Find ("Restart");
		quit = GameObject.Find ("Quit");
		restart.SetActive (false);
		quit.SetActive (false);
		winText.SetActive (false);
		loseText.SetActive (false);
	}
	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene (0);
	}
	public void Quit(){
		Application.Quit ();
	}
	public void GameOverScreen(){
		Time.timeScale = 0;
		loseText.SetActive (true);
		restart.SetActive (true);
		quit.SetActive (true);
	}
	public void WinScreen(){
		Time.timeScale = 0;
		winText.SetActive (true);
		restart.SetActive (true);
		quit.SetActive (true);
	}
}

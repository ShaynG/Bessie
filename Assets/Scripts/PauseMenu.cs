using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject pauseUI;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if (isPaused) {
				Resume ();
			} else {
				Pause();
			}
		}
	}


	public void Resume(){
		pauseUI.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;

	}

	public void Pause (){

		pauseUI.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene ("start");
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void QuitGame()
	{
		Debug.Log("Quitting");
		Application.Quit ();
		//SceneManager.LoadScene("end");
	}
}

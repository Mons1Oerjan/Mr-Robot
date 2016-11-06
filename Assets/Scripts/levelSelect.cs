using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

	private static int currentLevel = 1; //global variable
	private int maxLevels = 3;
	private string[] alreadyPlayed = new string[3];

	public void LoadLevelOne() {
		currentLevel = 1;
		SceneManager.LoadScene("Level1");
	}

	public void LoadLevelTwo() {
		currentLevel = 2;
		SceneManager.LoadScene("Level2");
	}

	public void LoadLevelThree() {
		currentLevel = 3;
		SceneManager.LoadScene("Level3");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void IncrementLevel() {
		currentLevel++;
		if (currentLevel <= maxLevels) { //load the following level
			SceneManager.LoadScene("Level"+currentLevel);
		} else { //game has been completed!
			currentLevel = 0;
			SceneManager.LoadScene("GameCompleted");
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Start () {
		Cursor.visible = true;
	}

	void Update() {
		//make sure cursor is visible and functional
		Cursor.visible = true;
		//Cursor.lockState

		//quit when escape is pressed
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
		//play new game when n is pressed
		if (Input.GetKey (KeyCode.N)) {
			SceneManager.LoadScene ("Level1");
		}
		//play level1 when 1 is pressed
		if (Input.GetKey (KeyCode.Alpha1)) {
			SceneManager.LoadScene ("Level1");
		}
		//play level2 when 2 is pressed
		if (Input.GetKey (KeyCode.Alpha2)) {
			SceneManager.LoadScene ("Level2");
		}
		//play level3 when 3 is pressed
		if (Input.GetKey (KeyCode.Alpha3)) {
			SceneManager.LoadScene ("Level3");
		}
		//quit game when q is pressed
		if (Input.GetKey (KeyCode.Q)) {
			Application.Quit ();
		}
	}
}

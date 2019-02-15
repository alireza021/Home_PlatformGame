using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btnmanager : MonoBehaviour {

	public void StartGameBtn(string newGame) {

		SceneManager.LoadScene (newGame);

	}

	public void Quit() {

		Application.Quit ();

	}
}

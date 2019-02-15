using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Interactions : MonoBehaviour {
	private int life;
	public Text lifeText;
	public Text loseText;
	public Text keyNeeded;
	public Text retry;

	private bool key = false;



	// Use this for initialization
	void Start () {
		life = 3;
		SetLifeText ();
		loseText.text = "";
		keyNeeded.text = "";
		retry.text = "";
	


	}
	
	// Update is called once per frame
	void Update () {
		if (life == 0) {
			loseText.text = "You lose! Press the SPACE bar to restart";
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = false;
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene ("Scene1");
			}
		}


	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Deathzone")) {
		
			life = life - 1;
			SetLifeText ();
			StartCoroutine(ShowMessage("Try again...", 3));

		}

		if (other.gameObject.CompareTag ("Key")) {
			life = life + 1;
			SetLifeText ();
			Destroy (GameObject.Find ("Key"));
			key = true;
			StartCoroutine(ShowMessage("I found the key... Wheres the dream portal?", 4));
		}
		if (other.gameObject.CompareTag ("end")) {
			SceneManager.LoadScene ("Menu");
		}

		if (other.gameObject.CompareTag ("Win")) {
			if (key) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);

			} else {
				StartCoroutine(ShowMessage("You need to find the key first!", 3));


			}


		}
		if (other.gameObject.name == "Dialog1") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("Here I am again...", 6));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog2") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("Is this a dream?", 6));
			Destroy(other.gameObject);

		}if (other.gameObject.name == "Dialog3") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("I have been here before...", 6));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog4") {
		StopAllCoroutines ();
		StartCoroutine(ShowMessage("I need to find the diamond key!", 4));
		Destroy(other.gameObject);

	}
		if (other.gameObject.name == "Dialog5") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("Feels just like home...", 4));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog6") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("The key...", 4));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog7") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("wow...", 4));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog8") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("how do I go back home?", 4));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog9") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("WAKE UP!", 3));
			Destroy(other.gameObject);

		}
		if (other.gameObject.name == "Dialog10") {
			StopAllCoroutines ();
			StartCoroutine(ShowMessage("WAKE UP! WAKE UP!!", 3));
			Destroy(other.gameObject);

		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Win")) {
			
				keyNeeded.text = "";

			}
			
	}


	void SetLifeText () {
		lifeText.text = life.ToString ();
	
	}

	IEnumerator ShowMessage (string message, float delay) {
		retry.text = message;
		retry.enabled = true;
		yield return new WaitForSeconds(delay);
		retry.enabled = false;
	}


}

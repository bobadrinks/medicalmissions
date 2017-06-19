using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedToCatch : MonoBehaviour {

	public GUIText failedText;
	int numFallen = 0;

	void Update() {
		failedText.text = "Missed: " + numFallen;
		/*if (numFallen > 50) {
			// "Game Over" Scene
			SceneManager.LoadScene ("GameOver");
		}*/
	}

	/*
	 * Function Name: OnTriggerEnter()
	 * Function Prototype: void OnTriggerEnter(Collider coll);
	 * Description: Takes care Cat colliding with food, wall, tail
	 * Parameters: arg1 - Collider coll -- Collider Triggered
	 * Side Effects: May set either "ate" or "gameEnd" to true
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void OnTriggerEnter(Collider coll) {
		// supply?
		if (coll.name.StartsWith ("Supply")) {
			// Remove the Caught Item
			numFallen++;
			coll.gameObject.SetActive (false);
			failedText.text = "Missed: " + numFallen;

		}
	}

}

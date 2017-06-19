/*
 * Filename: BackButtonStart.cs
 * Author: joswei
 * Description: When back button is pressed from start screen, quit application
 * Date: 05/18/2017
 * Sources of Help: 
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Back Button class
 * 
 * @author joswei
 * @version 1.0
 * @since May 18, 2017
 */
public class BackButtonStart : MonoBehaviour {

	/*
	 * Function name: Update
	 * Function prototype: void Update();
	 * Description: Update() is called once per frame; function checks for and
	 *              responds to a press of Android's back button.
	 * Parameters: None.
	 * Side Effects: Application quits if user presses Back Button.
	 * Error Conditions: None.
	 * Return Value: None.
	 */	void Update () {
		// If Android's Back Button is pressed, quit application
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}

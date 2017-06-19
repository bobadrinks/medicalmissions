/*
 * Filename: LaunchNewScene.cs
 * Author: joswei
 * Description: When back button is pressed, goes back to previous scene.
 * Date: 05/18/2017
 * Sources of Help: 
 */ 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/**
 * Class defines scene launching functionality
 * 
 * @author joswei
 * @version 1.0
 * @since May 18, 2017
 */
public class LaunchNewScene : MonoBehaviour {

	/*
	 * Function name: ClickGame
	 * Function prototype: public void ClickGame(string levelName);
	 * Description: Script is attached to a button to launch a new scene.
	 * Parameters: arg 1 - string levelName -- name of new scene to launch.
	 * Side Effects: Loads a new scene.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	public void ClickGame(string levelName) {
		// Going from one scene to another when a button is clicked
		SceneManager.LoadScene(levelName);
	}

}
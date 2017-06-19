/*
 * Filename: MoveSpriteScript.cs
 * Author: joswei
 * Description: Script that defines Sprite movement; uses BoxColliders with
 *              isTrigger option selected.
 * Date: April 19, 2017
 * Sources of help: 
 * https://unity3d.com/learn/tutorials/topics/scripting/object-pooling
 * https://forum.unity3d.com/threads/stop-wasting-memory-recycle-your-objects.34582/
 * https://forum.unity3d.com/threads/guitext-not-working.132887/
 * https://docs.unity3d.com/ScriptReference/Rigidbody-useGravity.html
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/counting-points-and-displaying-score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Sprite Movement class
 * 
 * @author joswei
 * @version 1.0
 * @since May 18, 2017
 */
public class MoveSpriteScript : MonoBehaviour {
	public GUIText scoreText;

	// How fast the Cat moves (300ms)
	public float movementSpeed = 1f;
	// Current Movement Direction (by default to the right)
	Vector2 dir = Vector2.right;
	Vector2 moveDir = Vector2.right;
	public string gameOver = "GameOver";

	// Did player catch something?
	bool caught = false;
	bool gameEnd = false;
	bool overrideMove = false;
	bool moveLeft = false;
	bool moveRight = true;

	float delta;
	int score = 0;

	/*
	 * Function name: Start
	 * Function prototype: void Start();
	 * Description: Used for initialization.
	 * Parameters: None.
	 * Side Effects: Initializes sprite with movementSpeed specified.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void Start() {
		// Move the sprite every 300ms
		InvokeRepeating("Move", movementSpeed, movementSpeed);
	}

	/*
	 * Function name: Update
	 * Function prototype: void Update();
	 * Description: Called once per frame; controls default movement.
	 * Parameters: None.
	 * Side Effects: Initializes sprite with movementSpeed specified.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void Update() {
		
		// Check if Sprite should move in a new direction
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			// Set delta to be change in x position
			delta = touchDeltaPosition.x;

			// If player swiped right, change Sprite's direction to be to the right;
			// else, Sprite should move to the left
			if (touchDeltaPosition.x > 0) {
				dir = Vector2.right;
			} else if (touchDeltaPosition.x < 0) {
				dir = -Vector2.right;
			}

		}

		// Did Sprite run into a wall on either side?
		if (overrideMove == true) {
			if (moveLeft == true) {
				dir = -Vector2.right;
			} else {
				dir = Vector2.right;
			}
		}

		// Update score text
		scoreText.text = "Score: " + score;

		// Win condition: score passes 20
		if (score >= 20) {
			SceneManager.LoadScene ("GameOver");
		}

	}

	/*
	 * Function name: Move
	 * Function prototype: void Move();
	 * Description: Called from Update(), moves Sprite once and checks if score
	 *              should increase.
	 * Parameters: None.
	 * Side Effects: Initializes sprite with movementSpeed specified.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void Move() {
		
		if (gameEnd) {
			return;
		}
			
		// Save current position (gap will be here)
		Vector2 v = transform.position;

		// Each time "move" is called, move once forward (to left or right)
		transform.Translate (dir);

		// If player just caught something, increase score
		if (caught) {
			// Increase score
			score++;
			if (PlayerPrefs.GetInt ("highscore") < score || PlayerPrefs.GetInt("highscore") == 0) {
				PlayerPrefs.SetInt ("highscore", score);
				PlayerPrefs.Save();
			}
			// Reset flag; caught object already added to score
			caught = false;
		}

	}

	/*
	 * Function Name: OnTriggerEnter
	 * Function Prototype: void OnTriggerEnter(Collider coll);
	 * Description: Takes care of Sprite colliding with supplies or a wall
	 * Parameters: arg1 - Collider coll -- Collider Triggered
	 * Side Effects: May set a flag (caught, moveLeft, moveRight, or overrideMove)
	 *               to true.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void OnTriggerEnter(Collider coll) {
		// food?
		if (coll.name.StartsWith ("Supply")) {
			// Get longer in next Move call
			caught = true;

			// Remove the Caught Item
			coll.gameObject.SetActive (false);

		} else if (coll.name.StartsWith ("left")) {
			overrideMove = true;
			moveRight = true;
			moveLeft = false;
		} else if (coll.name.StartsWith ("right")) {
			overrideMove = true;
			moveLeft = true;	
			moveRight = false;
		}
	}

	/*
	 * Function Name: OnTriggerExit
	 * Function Prototype: void OnTriggerExit(Collider coll);
	 * Description: Takes care of Sprite colliding with supplies or a wall.
	 * Parameters: arg1 - Collider coll -- Collider Triggered
	 * Side Effects: Sets overrideMove flag to false.
	 * Error Conditions: None.
	 * Return Value: None.
	 */
	void OnTriggerExit(Collider coll) {
		overrideMove = false;
	}

}
/*
 * Name: Jocelyn Wei
 * Sources of Help:
 * http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveDownUp : MonoBehaviour {

	int direction = -1; // int direction where 0 is stay, 1 up, -1 down
	int top = 3;
	int bottom = -3;
	float speed = 2;


	void Update() {
		transform.Translate (0, speed * direction * Time.deltaTime, 0);
		if (Input.touchCount == 1) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos)) {
				direction = -direction;
			}
		}
	}

	void OnTriggerEnter(Collider coll) {
		// Move up and down
		if (coll.name.StartsWith ("top_border")) {
			// Collided with top, move down
			direction = -1;
		} else if (coll.name.StartsWith ("bottom_border")) {
			// Collided with bottom, move up
			direction = 1;
		} else if (coll.name.StartsWith ("Diag1")) {
			SceneManager.LoadScene ("Game1Over");
		}
	}

}
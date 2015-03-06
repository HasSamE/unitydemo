using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	// Speed to be modified in the Inspector
	public float speed = 2.0f;

	// Use this for initialization
	void Start () {
		// Give the ball some initial movement direction
		rigidbody2D.velocity = new Vector2(1, 1).normalized * speed;
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider

		// Hit the left Racket?
		if (col.gameObject.name == "RacketLeft") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(1, y).normalized;
			
			// Set Velocity with dir * speed
			rigidbody2D.velocity = dir * speed;
		}
		
		// Hit the right Racket?
		if (col.gameObject.name == "RacketRight") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;
			
			// Set Velocity with dir * speed
			rigidbody2D.velocity = dir * speed;
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketHeight) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		// print out the ball and racket position
		Debug.Log("ball:" + ballPos.y + " racket:" + racketPos.y);
		return (ballPos.y - racketPos.y) / racketHeight;
	}
}

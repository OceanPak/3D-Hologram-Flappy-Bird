using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	float forwardSpeed = 1f; // force pushing bird forward
	float flapSpeed = 200f; // force pushing bird upward

	Rigidbody rigidbody; // declare rigidbody class

	Renderer rend;

	bool didFlap = false; // check whether the force is pushing upwards on the bird

	bool dead = false; // check whether the bird is dead

	public Material newMaterialRef;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>(); // initialize Rigidbody as rigidbody
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}

	// Do Graphic & Input updates here
	void Update () {
		if (dead == false) { // if the bird isn’t dead
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) { // if the space bar or mouse click is pressed
				didFlap = true; // then a force is applied to the bird, pushing it upwards
			}  
		}
	}


	// Update is called once per frame
	// Once every 50th of a second
	// Do physics engine updates here
	void FixedUpdate () { // 50 times a second

		Physics.gravity = new Vector3(0, -4F, 0); // apply a 4 force gravity with the Physics System

		rigidbody.AddForce (Vector3.right * forwardSpeed); // apply a Vector3.right force to the rigidbody.

		if (didFlap) { // if the bird flaps
			rigidbody.AddForce (Vector3.up * flapSpeed); // then add an upward force to the bird
			didFlap = false; // remove the upward force. This mimics the Flappy Bird mechanics. 
		}

		if (rigidbody.velocity.y > 0) { // if the bird is moving upwards (spacebar is pressed)
			transform.rotation = Quaternion.Euler (0, 0, 0); // turn the bird upright
		} else {
			float angle = Mathf.Lerp (0, -90, -rigidbody.velocity.y / 2f); // calculate the angle that the bird turns as it falls
			transform.rotation = Quaternion.Euler (0, 0, angle); // apply the angle
		}

	}

	void OnCollisionEnter(Collision collision) { // create a function OnCollisionEnter, and apply the Collision system into the function as collision
		dead = true; // if the bird collides, set the bird to dead
		rend.material = newMaterialRef; // Material didn't work at first
		rigidbody.AddForce (Vector3.right * 10f); // Adjusted force because it was falling
		return;
	}

}
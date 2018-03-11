using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	float temp = 0;

	bool isRepeat = false; // Made by myself to maintain the same movement between upper pole and lower pole. 

	void OnTriggerEnter(Collider collider1) {

		if (collider1.name == "Cylinder (Top)") { // Tested a lot with this. Tried using pos.x = 0, but it didn't work. Inconsistent if you add or use +=

			if (isRepeat == false) {

				Vector3 pos = collider1.transform.position;

				pos.x += 14;

				collider1.transform.position = pos;

				print (pos); // Used to debug

				temp = pos.x;

				isRepeat = true;
			
			}

			if (isRepeat == true) {

				Vector3 pos = collider1.transform.position;

				pos.x = temp; // Had to actually understand how this works. 

				collider1.transform.position = pos;

				isRepeat = false;
			}

		}

		if (collider1.name == "Cylinder (Bottom)") {

			if (isRepeat == false) {

				Vector3 pos = collider1.transform.position;

				pos.x += 14;

				collider1.transform.position = pos;

				temp = pos.x;

				isRepeat = true;

			}

			if (isRepeat == true) {

				Vector3 pos = collider1.transform.position;

				pos.x = temp;

				collider1.transform.position = pos;

				isRepeat = false;
			}

		}

		if (collider1.name == "Plane") {
			float widthOfBGObject = collider1.bounds.size.x;

			Vector3 pos = collider1.transform.position;

			pos.x += widthOfBGObject / 6; // Guess and Check

			collider1.transform.position = pos;

			pos.x = 0;
		}

	}
}

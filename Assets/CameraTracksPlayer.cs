using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

	Transform player; // calls upon the Transform class

	float offSetX; // float value for the offSetX

	// Use this for initialization
	void Start () {
		GameObject player_game_object = GameObject.FindGameObjectWithTag ("Player"); // finds the GameObject with the tag "Player" - which is the cube
		if (player_game_object == null) { // if not found
			Debug.LogError ("Couldn't find an object with tag 'Player'!"); // it will print error message
			return; // stop program
		}

		player = player_game_object.transform; // allow the change of position, rotation and scale of the cube

		offSetX = transform.position.x - player.position.x; // current camera position - current cube position = distance the camera needs to move

	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) { // as long as the player is detected
			Vector3 pos = transform.position; // get the position of the current camera
			pos.x = player.position.x + offSetX; // change the x position of the camera by the distance to catch up with the cube
			transform.position = pos; // apply the new position to the camera position
		}
	}
}

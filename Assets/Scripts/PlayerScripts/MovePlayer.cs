using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float maxSpeed = 20.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		ManageMovement ();
	}

	
	void ManageMovement(){
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
			//Vector3 direction = transform.up*inputX + transform.right*inputY; //Direction relative to rotation
			Vector3 direction = new Vector3 (inputX, inputY,0); //Direction relative to screen
			direction.Normalize ();
			transform.position = transform.position + direction*(maxSpeed*Time.deltaTime);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FetchInput : MonoBehaviour{
	private bool upKey;
	private bool leftKey;
	private bool rightKey;
	private bool downKey;
	private bool spaceKey;
	private bool leftClick;
	public bool getLeftClick{get{return leftClick;}}
	public bool getUpKey{get {return upKey;}}
	public bool getLeftKey{get{return leftKey;}}
	public bool getRightKey{get{return rightKey;}}
	public bool getDownKey{get{return downKey;}}
	public bool getSpaceKey{get{return spaceKey;}}

	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			upKey = true;
		} else if(Input.GetKeyUp(KeyCode.W)){
			upKey = false;
		}
		if (Input.GetKey (KeyCode.A)) {
			leftKey = true;
		} else if(Input.GetKeyUp(KeyCode.A)){
			leftKey = false;
		}
		if (Input.GetKey (KeyCode.D)) {
			rightKey = true;
		} else if(Input.GetKeyUp(KeyCode.D)){
			rightKey = false;
		}
		if (Input.GetKey (KeyCode.S)) {
			downKey = true;
		} else if(Input.GetKeyUp(KeyCode.S)){
			downKey = false;
		}
		if (Input.GetKey (KeyCode.Space)) {
			spaceKey = true;
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			spaceKey = false;
		}
		if (Input.GetMouseButton (0)) {
			leftClick = true;
		} else if (Input.GetMouseButtonUp (0)) {
			leftClick = false;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float minimumMouseDistance;
	[SerializeField]private float rampSpeed;
	public float movementSpeed;
	private Rigidbody2D rb;
	private float lerpTime = 0;
	private FetchInput input;
	void Start () {
		input = Camera.main.GetComponent<FetchInput> ();
	}
	void Update () {
		FollowMouse ();
		if (input.getUpKey) {
			MovePosition (new Vector3 (0, Mathf.Lerp (0, movementSpeed, lerpTime += Time.deltaTime * rampSpeed), 0));
		}
		if (input.getDownKey) {
			MovePosition (new Vector3 (0, -Mathf.Lerp (0, movementSpeed, lerpTime += Time.deltaTime * rampSpeed), 0));
		}
		if (input.getLeftKey) {
			MovePosition (new Vector3 (-Mathf.Lerp (0, movementSpeed, lerpTime += Time.deltaTime * rampSpeed), 0, 0));
		}
		if (input.getRightKey) {
			MovePosition (new Vector3 (Mathf.Lerp (0, movementSpeed, lerpTime += Time.deltaTime * rampSpeed), 0, 0));
		}
		if (!input.getLeftKey && !input.getRightKey && !input.getUpKey && !input.getDownKey) {
			lerpTime = 0;
		}
	}
	void FollowMouse(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		if (Vector3.Distance (mousePos, transform.position) <= minimumMouseDistance) {
			return;
		} 
		mousePos = mousePos - transform.position;
		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
	}
	void MovePosition(Vector3 direction){
		transform.position += direction;
	}
}
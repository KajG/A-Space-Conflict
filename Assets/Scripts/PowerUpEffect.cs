using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffect : MonoBehaviour {
	public float spinningSpeed;
	void Start () {
		
	}
	
	void Update () {
		transform.localEulerAngles += new Vector3 (0, 0, spinningSpeed * Time.deltaTime);
	}
}

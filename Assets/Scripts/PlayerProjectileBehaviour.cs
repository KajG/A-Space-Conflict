using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehaviour : MonoBehaviour {
	[SerializeField]private float projectileSpeed;
	void Update () {
		transform.position += transform.up * Time.deltaTime * projectileSpeed;
	}
}
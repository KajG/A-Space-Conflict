using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : MonoBehaviour {
	[SerializeField]private float projectileSpeed;
	[SerializeField]private float damage;
	public float getDamage{get{return damage;}}
	void Update () {
		transform.position += transform.up * Time.deltaTime * projectileSpeed;
	}
}
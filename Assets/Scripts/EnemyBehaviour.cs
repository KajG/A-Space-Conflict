using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	[SerializeField]private float damage;
	[SerializeField]private float shootDistance;
	[SerializeField]private GameObject projectile;
	[SerializeField]private float projectileAliveTime;
	[SerializeField]private float attackSpeed;
	[SerializeField]private float moveSpeed;
	[SerializeField]private float chaseDistance;
	[SerializeField]private float stopDistance;
	private float attackTimer;
	private GameObject player;
	void Start () {
		player = GameObject.Find ("Player");
		attackTimer = attackSpeed;
	}
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) <= shootDistance) {
			Attack ();
		}
		if (Vector3.Distance (transform.position, player.transform.position) <= chaseDistance) {
			LookAtPlayer ();
			if(Vector3.Distance (transform.position, player.transform.position) >= stopDistance)
			Chase ();
		}
	}
	void LookAtPlayer(){
		Transform playerPos = player.transform;
		Vector3 lookDirection = playerPos.transform.position - transform.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
	}
	void Attack(){
		attackTimer -= Time.deltaTime;
		if (attackTimer <= 0) {
			Destroy (Instantiate (projectile, transform.position, transform.rotation), projectileAliveTime);
			attackTimer = attackSpeed;
		}
	}
	void Chase(){
		transform.position += transform.up * Time.deltaTime * moveSpeed;
	}
}

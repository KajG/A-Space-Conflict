using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField]private GameObject projectile;
	[SerializeField]private float projectileAliveTime;
	[SerializeField]private float damage;
	public float getDamage{get{return damage;}set{damage = value;}}
	public float attackSpeed;
	private float attackTimer;
	public List<Transform> muzzles = new List<Transform> ();
	private FetchInput input;
	void Start () {
		input = Camera.main.GetComponent<FetchInput> ();
	}
	void Update () {
		if (input.getLeftClick) {
			Shoot ();
		}
	}
	void Shoot(){
		attackTimer -= Time.deltaTime;
		if (attackTimer <= 0) {
			for (int i = 0; i < muzzles.Count; i++) {
				Destroy (Instantiate (projectile, muzzles [i].position, transform.rotation), projectileAliveTime);
			}
			attackTimer = attackSpeed;
		}
	}
}
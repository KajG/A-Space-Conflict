using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D projectile){
		if (projectile.gameObject.tag == "Projectile" || projectile.gameObject.tag == "ProjectileEnemy") {
			Destroy (projectile.gameObject);
		}
	}
}

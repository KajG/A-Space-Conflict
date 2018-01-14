using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	[SerializeField]private float health;
	public GameObject explosion;
	public float getHealth{get{return health;}}
	private DamageTextEffect damageText;
	private UpgradeController upgrade;
	private GameOver gameOver;
	void Start () {
		damageText = Camera.main.GetComponent<DamageTextEffect> ();
		upgrade = Camera.main.GetComponent<UpgradeController> ();
		gameOver = Camera.main.GetComponent<GameOver> ();
	}
	void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "ProjectileEnemy") {
			TakeDamage(obj.gameObject.GetComponent<EnemyProjectileBehaviour> ().getDamage);
			Destroy(obj.gameObject);
		}
		if (obj.gameObject.tag == "PowerUp") {
			upgrade.shipUpgrade1 = true;
			Destroy(obj.gameObject);
		}
	}
	void TakeDamage(float damage){
		damageText.CreateText (damage, transform);
		if (damage >= health) {
			health = 0;
			Destroy(Instantiate (explosion, transform.position, Quaternion.identity), 1f);
			gameOver.GameOverScreen ();
			Destroy (this.gameObject);
		} else {
			health -= damage;
		}
	}
}
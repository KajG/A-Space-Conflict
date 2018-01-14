using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField]private float health;
	public float getHealth{get{return health;}}
	private DamageTextEffect damageText;
	private EnemyHealthUI healthSlider;
	private MissionController mission;
	public GameObject explosion;
	void Start () {
		damageText = Camera.main.GetComponent<DamageTextEffect> ();
		mission = Camera.main.GetComponent<MissionController> ();
		healthSlider = GetComponent<EnemyHealthUI> ();
	}
	void OnTriggerEnter2D(Collider2D projectile){
		if (projectile.gameObject.tag == "Projectile") {
			TakeDamage(GameObject.Find("Player").GetComponent<PlayerShooting>().getDamage);
			Destroy(projectile.gameObject);
		}
	}
	void TakeDamage(float damage){
		damageText.CreateText (damage, transform);
		if (damage >= health) {
			mission.AddKill ();
			Destroy(Instantiate (explosion, transform.position, Quaternion.identity), 1f);
			Destroy (this.gameObject);
		} else {
			health -= damage;
		}
		healthSlider.UpdateSlider ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthUI : MonoBehaviour {

	private Slider slider;
	private EnemyHealth enemyHealth;
 	void Start () {
		slider = GetComponentInChildren<Slider> ();
		enemyHealth = GetComponent<EnemyHealth> ();
		slider.maxValue = enemyHealth.getHealth;
		UpdateSlider ();
	}
	public void UpdateSlider(){
		slider.value = enemyHealth.getHealth;
	}
}
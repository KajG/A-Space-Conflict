using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour {
	private PlayerHealth playerHealth;
	private Image healthBar;
	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		healthBar = GetComponent<Image> ();
	}
	void Update () {
		healthBar.fillAmount = playerHealth.getHealth / 50;
	}
}
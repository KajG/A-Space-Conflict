using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthTextUI : MonoBehaviour {
	private PlayerHealth health;
	private Text healthText;
	void Start () {
		health = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		healthText = GetComponent<Text> ();
	}
	
	void Update () {
		healthText.text = "" + health.getHealth;
	}
}

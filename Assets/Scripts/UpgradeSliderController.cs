using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeSliderController : MonoBehaviour {
	public Slider attackSpeedSlider;
	public Slider movementSlider;
	public Slider damageSlider;
	void Start () {
		attackSpeedSlider = attackSpeedSlider.GetComponent<Slider> ();
		movementSlider = movementSlider.GetComponent<Slider> ();
		damageSlider = damageSlider.GetComponent<Slider> ();
	}
	public void SetupSlider(float maxValue, string name){
		switch (name) {
		case "atk":
			attackSpeedSlider.maxValue = maxValue;
			break;
		case "move":
			movementSlider.maxValue = maxValue;
			break;
		case "dmg":
			damageSlider.maxValue = maxValue;
			break;
		default:
			break;
		}
	}
	public void UpdateSlider(float value, string name){
		switch (name) {
		case "atk":
			attackSpeedSlider.value += value;
			break;
		case "move":
			movementSlider.value += value;
			break;
		case "dmg":
			damageSlider.value += value;
			break;
		default:
			break;
		}
	}
}

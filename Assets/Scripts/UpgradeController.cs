using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeController : MonoBehaviour {
	public bool shipUpgrade1;
	public bool shipUpgrade2;
	public float attackSpeedUpgrade;
	public float damageUpgrade;
	public float movementSpeedUpgrade;
	public Button attackButton;
	public Button damageButton;
	public Button movementButton;
	public int upgradeAmount;
	private bool buttonsActive;
	private int killIndex;
	private MissionController missions;
	public List<Transform> muzzles = new List<Transform> ();
	public List<int> requiredKills = new List<int> ();
	private PlayerMovement playerMovement;
	private PlayerShooting playerShooting;
	private UpgradeSliderController upgradeSliders;
	public bool maxUpgraded;
	void Start () {
		upgradeSliders = GetComponent<UpgradeSliderController> ();
		playerShooting = GameObject.Find ("Player").GetComponent<PlayerShooting> ();
		playerMovement = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
		missions = GetComponent<MissionController> ();
		upgradeSliders.SetupSlider (attackSpeedUpgrade * upgradeAmount, "atk");
		upgradeSliders.SetupSlider (damageUpgrade * upgradeAmount, "dmg");
		upgradeSliders.SetupSlider(movementSpeedUpgrade * upgradeAmount, "move");
	}
	void Update () {
		if (shipUpgrade1) {
			playerShooting.muzzles.Clear ();
			UpgradeShip (muzzles [1]);
			UpgradeShip (muzzles [2]);
		}
		if (shipUpgrade2) {
			playerShooting.muzzles.Clear ();
			for (int i = 0; i < muzzles.Count; i++) {
				UpgradeShip (muzzles [i]);
			}
		}
	}
	public void Upgrade(string name){
		switch (name) {
		case "atk":
			if (upgradeSliders.attackSpeedSlider.value == upgradeSliders.attackSpeedSlider.maxValue) {
				return;
			}
			playerShooting.attackSpeed -= attackSpeedUpgrade;
			upgradeSliders.UpdateSlider (attackSpeedUpgrade, name);
			break;
		case "move":
			if (upgradeSliders.movementSlider.value == upgradeSliders.movementSlider.maxValue) {
				return;
			}
			playerMovement.movementSpeed += movementSpeedUpgrade;
			upgradeSliders.UpdateSlider (movementSpeedUpgrade, name);
			break;
		case "dmg":
			if (upgradeSliders.damageSlider.value == upgradeSliders.damageSlider.maxValue) {
				return;
			}
			playerShooting.getDamage += damageUpgrade;
			upgradeSliders.UpdateSlider (damageUpgrade, name);
			break;
		default:
			break;
		}
	}
	void UpgradeShip(Transform index){
		playerShooting.muzzles.Add (index);
	}
	public void CheckKills(){
		if (missions.kills == missions.killRequirement && missions.kills == requiredKills [requiredKills.Count - 1]) {
			maxUpgraded = true;
			missions.RefreshKillCountText ();
			EnableButtons ();
		} else if(missions.kills == missions.killRequirement) {
			killIndex++;
			missions.killRequirement = requiredKills [killIndex];
			missions.RefreshKillCountText ();
			EnableButtons ();
		}
	}
	public void DisableButtons(){
		attackButton.interactable = false;
		damageButton.interactable = false;
		movementButton.interactable = false;
	}
	void EnableButtons(){
		if (upgradeSliders.attackSpeedSlider.value == upgradeSliders.attackSpeedSlider.maxValue) {
		} else {
			attackButton.interactable = true;
		}
		if (upgradeSliders.damageSlider.value == upgradeSliders.damageSlider.maxValue) {
		} else {
			damageButton.interactable = true;
		}
		if (upgradeSliders.movementSlider.value == upgradeSliders.movementSlider.maxValue) {
		} else {
			movementButton.interactable = true;
		}
	}
}
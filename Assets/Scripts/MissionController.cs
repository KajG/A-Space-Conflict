using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionController : MonoBehaviour {
	[SerializeField]private string killText;
	public int killRequirement;
	public int kills;
	public int enemyCount;
	private Text killCount;
	private UpgradeController upgrades;
	private GameOver gameOver;
	void Start () {
		killCount = GameObject.Find ("KillCount").GetComponent<Text> ();
		gameOver = Camera.main.GetComponent<GameOver> ();
		upgrades = GetComponent<UpgradeController> ();
		RefreshKillCountText ();
	}
	public void AddKill(){
		kills++;
		upgrades.CheckKills ();
		RefreshKillCountText ();
		if (kills == enemyCount) {
			gameOver.WinScreen ();
		}
	}
	public void RefreshKillCountText(){
		if (upgrades.maxUpgraded) {
			killCount.text = "Upgrades depleted";
		} else {
			killCount.text = killText + kills + "/" + killRequirement;
		}
	}
}
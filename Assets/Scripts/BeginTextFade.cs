using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BeginTextFade : MonoBehaviour {
	private Text text;

	void Start () {
		text = GetComponent<Text> ();
		StartCoroutine (FadeText ());
	}
	IEnumerator FadeText(){
		float alpha = 1;
		while (alpha >= 0) {
			alpha -= Time.fixedDeltaTime / 10;
			text.color = new Color (text.color.r, text.color.g, text.color.b, alpha);
			yield return null;
		}
		Destroy (gameObject);
	}
}

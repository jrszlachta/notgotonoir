using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour {
	public Image splashImage;
	public Text splashText;
	public float fadeIn = 2.5f;
	public float fadeOut = 2.5f;
	public float splashTime = 3f;
	public string loadLevel;

	IEnumerator Start() {
		splashImage.canvasRenderer.SetAlpha(0.0f);
		splashText.canvasRenderer.SetAlpha(0.0f);

		FadeIn();
		yield return new WaitForSeconds(splashTime);
		FadeOut();
		yield return new WaitForSeconds(fadeOut+0.5f);
		SceneManager.LoadScene(loadLevel);
	}

	void FadeIn() {
		splashImage.CrossFadeAlpha(1.0f, fadeIn, false);
		splashText.CrossFadeAlpha(1.0f, fadeIn, false);
	}

	void FadeOut() {
		splashImage.CrossFadeAlpha(0f, fadeOut, false);
		splashText.CrossFadeAlpha(0f, fadeOut, false);
	}
}

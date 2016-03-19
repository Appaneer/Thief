using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GUITexture fader;
	[Range(0,3)]
	public float fadeSpeed; // how quickly the screen fades in and out
	private Color faderColor;
	[HideInInspector]
	public bool isStarting;
	[HideInInspector]
	public bool isFinishing;

	void Start()
	{
		isStarting = true;
		isFinishing = false;
		fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		faderColor = fader.color;
	}

	void Update(){
		if (isStarting) 
			StartScene();
		if (isFinishing) {
			fader.enabled = true;
			FadeToBlack ();
		}
	}

	void FadeToClear()
	{
		fader.color = Color.Lerp(fader.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void FadeToBlack()
	{
		fader.color = Color.Lerp(fader.color, faderColor, fadeSpeed * Time.deltaTime);
		if (fader.color.a >= 0.6f) {
			SceneManager.LoadScene ("Test");
		}
	}

	void StartScene()
	{
		FadeToClear();

		if (fader.color.a <= 0.1f)
		{
			fader.color = Color.clear;
			fader.enabled = false;
			isStarting = false;
		}
	}
		
	public void play(){
		if(!isStarting)
			isFinishing = true;
	}

}

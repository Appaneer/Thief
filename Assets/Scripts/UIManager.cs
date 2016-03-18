using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
/*
	public Button settingButton;
	public Button helpButton;
	public Button infoButton;
	public Button pauseButton;
	public Button playButton;
	public Button shopButton;
	public Button resetButton;
*/
	public void play(){
		SceneManager.LoadScene ("Test");
	}

}

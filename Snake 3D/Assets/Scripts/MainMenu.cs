using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public string newGameScene;
   
	public void NewGame()
	{
		SceneManager.LoadScene(newGameScene);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
		
	public void Controls()
	{
		Time.timeScale = 0;

	}
	void OnGUI()
	{
		if (Time.timeScale == 0)
		{
			GUI.color=Color.blue;
			GUI.skin.label.fontSize = 60;
			GUI.Label(new Rect(0, Screen.height * 0.1f, Screen.width, 65), "How to Play");
			GUI.skin.box.fontSize = 30;
			GUI.color=Color.red;
			GUI.Box(new Rect(0, Screen.height * 0.3f, Screen.width, 150), "Press Up, Down, Left, and Right keys to change the snake direction\nPress P or Tab to pause the game");
			if (Input.anyKeyDown){
				Time.timeScale = 1;
			}
		} 
	}
}
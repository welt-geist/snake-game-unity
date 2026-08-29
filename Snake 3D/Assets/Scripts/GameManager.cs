using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public int score = 0;
	public int hscore = 0;
	[SerializeField] private Text scoreLabel;
	[SerializeField] private Text hiScoreLabel;
	private GameObject snake;
	private Player player;


	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteKey("hscore");
		snake = GameObject.FindGameObjectWithTag ("Player");
		player = snake.GetComponent<Player> ();
		hscore = PlayerPrefs.GetInt ("hscore", hscore);
	}

	// Update is called once per frame
	void Update () {
		score = player.count - 1;
		scoreLabel.text = "Score: " + score;
			if(score > hscore)
		{
			hscore = score;
			PlayerPrefs.SetInt ("hscore", hscore);
		}
			hiScoreLabel.text = "Highest Score: " + hscore;
		}

	void OnGUI()
	{
		if (Time.timeScale == 0)
		{
			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.3f, 100, 30), "Continue Game"))
			{
				Time.timeScale = 1;
			}
			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "Exit Game"))
			{
				Application.Quit();
			}
			GUI.color=Color.red;
			GUI.skin.label.fontSize = 40;
			GUI.Label(new Rect(0, Screen.height * 0.1f, Screen.width, 60), "Pause Menu");
			GUI.color=Color.blue;
			GUI.skin.label.fontSize = 30;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;


			}
		if (player.isDead)
		{            
			GUI.skin.label.fontSize = 50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "Game Over");
			GUI.skin.label.fontSize = 20;

			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "Try again"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "Exit Game"))
			{
				Application.Quit();
			}
		}
	}
}

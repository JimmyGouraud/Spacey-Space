using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
	public GameObject GameOverUI;
	public Life playerLife;

	void Start()
	{
		GameOverUI.SetActive(false);
		playerLife.PlayerDeath += GameOver;
	}

	void GameOver()
	{
		Time.timeScale = 0f;
		GameOverUI.SetActive(true);
	}

	public void Replay()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public static Score Instance;
	public TextMeshProUGUI textScore;

	int score = 0;

	// Use this for initialization
	void Start()
	{
		if (Instance == null) {
			Instance = this;
		} 

		if (Instance != this) {
			Destroy(this);
		}

		UpdateHUD();
	}
	
	public void AddPoints(int points)
	{
		score += points;
		UpdateHUD();
	}
	
	void UpdateHUD()
	{
		Debug.Log("UpdateHUD : " + "Score: " + score);
		textScore.SetText("Score: " + score);
	}
}

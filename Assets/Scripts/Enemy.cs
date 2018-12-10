using UnityEngine;


public class Enemy : MonoBehaviour
{
	public int points = 250; // How much is the enemy worth

	void OnDestroy()
	{
		Score.Instance.AddPoints(points);
	}
}

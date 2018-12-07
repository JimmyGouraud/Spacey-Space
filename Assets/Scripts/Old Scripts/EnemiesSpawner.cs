using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
	public GameObject Enemy;
	public GameObject Target;


	void Start()
	{
		CircleSpawn();
	}

	void CircleSpawn()
	{
		float radius = 20f;
		int nbEnemies = 50;
		float offset = 2 * Mathf.PI / (float)nbEnemies;

		for (int i = 0; i < nbEnemies; i++) {
			GameObject enemy = Instantiate(Enemy);
			float delta = i * offset;
			float x = Target.transform.position.x + radius * Mathf.Cos(delta);
			float z = Target.transform.position.y + radius * Mathf.Sin(delta);
			enemy.transform.position = new Vector3(x, enemy.transform.position.y, z);
		}
	}
}

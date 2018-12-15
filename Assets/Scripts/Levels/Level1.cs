using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
	public GameObject enemyPrefab;


	void OnEnable()
	{
		Initialisation();
	}

	void Initialisation()
	{
		Vector2 TopCenterScreen = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
		Vector2 spawnPos = TopCenterScreen + new Vector2(0, 1);

		int nbEnemyColumn = 7;
		int nbEnemyLine = 5;

		Vector2 offsetPosition = enemyPrefab.transform.lossyScale * 1.3f;
		Vector2 sizeConfiguration = new Vector2(offsetPosition.x * (nbEnemyColumn - 1), offsetPosition.y * nbEnemyLine);
		
		float topOffset = 0.5f;
		Vector2 firstPos = new Vector2(TopCenterScreen.x - sizeConfiguration.x / 2f, TopCenterScreen.y - sizeConfiguration.y - topOffset);


		for (int line = 0; line < nbEnemyLine; line++) {
			for (int column = 0; column < nbEnemyColumn; column++) {
				if ((line % 2 != 0) && (column == nbEnemyColumn - 1)) {
					continue;
				}

				GameObject enemy = Instantiate(enemyPrefab, this.transform);
				enemy.transform.position = spawnPos;

				Vector2 destinationPosition = firstPos + new Vector2(offsetPosition.x * column, offsetPosition.y * line);
				if (line % 2 != 0) {
					destinationPosition += new Vector2(offsetPosition.x / 2f, 0);
				}

				enemy.GetComponent<Enemy>().SetPositioningDestination(destinationPosition);
			}
		}
	}
}

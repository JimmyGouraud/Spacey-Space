using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public GameObject enemyPrefab;
	Vector3 middleTopOffset;


	void Start ()
	{
		middleTopOffset = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
		middleTopOffset.z = 0;

		CreateLevel1();
	}

	public void CreateLevel1()
	{
		int nbEnemyPerLine = 7;
		int nbEnemyLine = 4;
		int nbEnemy = nbEnemyLine * nbEnemyPerLine;
		Vector2 enemyScale = enemyPrefab.transform.lossyScale * 1.5f;
		Vector2 offsetPosition = new Vector2(middleTopOffset.x - ((nbEnemyPerLine - 1) * enemyScale.x / 2f),
											 middleTopOffset.y - nbEnemyLine * enemyScale.y);

		for (int i = 0; i < nbEnemy; i++) {
			if ((i % nbEnemyPerLine == nbEnemyPerLine - 1) && ((i / nbEnemyPerLine) % 2 != 0)) {
				continue;
			}

			GameObject enemy = Instantiate(enemyPrefab, this.transform);

			float offsetX = ((i / nbEnemyPerLine) % 2 == 0) ? 0f : enemyScale.x / 2f;
			Vector2 destinationPosition = offsetPosition + new Vector2(offsetX + (i % nbEnemyPerLine) * enemyScale.y,(i / nbEnemyPerLine) * enemyScale.x);
			Vector2 initPosition = new Vector2(middleTopOffset.x + 1, middleTopOffset.y);

			enemy.transform.position = initPosition;
			enemy.GetComponent<Enemy>().SetPositioningDestination(destinationPosition);
		}
	}
}

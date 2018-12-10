using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
	public GameObject playerLifePrefab;
	public Life playerLife;
	public float offset = 5f;

	void Start()
	{
		playerLife.UpdateLifeCount += UpdateLifeUI;
		UpdateLifeUI(playerLife.nbLife);
	}

	public void UpdateLifeUI(int nbLife)
	{
		int nbLifeUI = this.transform.childCount;

		if (nbLife < nbLifeUI) {
			for (int i = nbLife; i < nbLifeUI; i++) {
				Destroy(this.transform.GetChild(i).gameObject);
			}
		} else if (nbLife > nbLifeUI) {
			Vector2 lifeSize = playerLifePrefab.GetComponent<RectTransform>().sizeDelta;
			Vector2 lifePosition = playerLifePrefab.GetComponent<RectTransform>().anchoredPosition;

			for (int i = nbLifeUI; i < nbLife; i++) {
				GameObject life = Instantiate(playerLifePrefab, this.transform);
				life.GetComponent<RectTransform>().anchoredPosition = new Vector2(lifePosition.x, lifePosition.y - (lifeSize.y + offset) * i);
			}
		}
	}
}

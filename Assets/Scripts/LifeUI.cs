using UnityEngine;


public class LifeUI : MonoBehaviour
{
	public GameObject playerLifePrefab;
	public Life playerLife;

	Vector2 lifeSize, lifePosition;
	int lifePixelOffet;

	void Start()
	{
		playerLife.UpdateLifesCount += UpdateLifesUI;

		Vector2 lifeSize = playerLifePrefab.GetComponent<RectTransform>().sizeDelta;
		Vector2 lifePosition = playerLifePrefab.GetComponent<RectTransform>().anchoredPosition;
		lifePixelOffet = (int)Mathf.Floor(lifeSize.y * 1.5f);
		UpdateLifesUI(playerLife.LifesCount);
	}

	public void UpdateLifesUI(int lifesCount)
	{
		int lifesCountUI = this.transform.childCount;

		if (lifesCount < lifesCountUI) {
			for (int i = lifesCount; i < lifesCountUI; i++) {
				Destroy(this.transform.GetChild(i).gameObject);
			}
		}
		else if (lifesCount > lifesCountUI) {
			for (int i = lifesCountUI; i < lifesCount; i++) {
				GameObject life = Instantiate(playerLifePrefab, this.transform);
				life.GetComponent<RectTransform>().anchoredPosition = new Vector2(lifePosition.x, lifePosition.y - (lifeSize.y + lifePixelOffet) * i);
			}
		}
	}
}

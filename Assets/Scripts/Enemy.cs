using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
	public int points = 250; // How much is the enemy worth
	public float speed = 20f;

	Vector2 positioning = Vector2.zero;
	GameObject playerGO;

	void Awake()
	{
		playerGO = GameObject.FindGameObjectWithTag("Player");
	}

	void OnEnable()
	{
		StartCoroutine(Movement());
	}

	public void SetPositioningDestination(Vector2 position)
	{
		positioning = position;
	}

	IEnumerator Movement()
	{       
		// First step : wait a positioning destination
		yield return new WaitUntil(() => Vector2.Distance(positioning, this.transform.position) > Mathf.Epsilon);

		// Second step : positioning
		yield return Positioning();

		// Third step : random movement
		yield return RandomMovement();
	}

	IEnumerator Positioning()
	{
		yield return GoToPosition(positioning);
	}

	IEnumerator RandomMovement()
	{
		while (true) {
			float timeBeforeMovement = Random.Range(1f, 20f);
			yield return new WaitForSeconds(timeBeforeMovement);

			yield return GoToPosition(playerGO.transform.position);
			yield return GoToPosition(positioning);
		}
	}
	
	IEnumerator GoToPosition(Vector2 positionDestination)
	{
		float step = speed * Time.deltaTime;

		while (Vector2.Distance(positionDestination, this.transform.position) > Mathf.Epsilon) {
			transform.position = Vector2.MoveTowards(transform.position, positionDestination, step);
			yield return null;
		}
	}

	void OnDestroy()
	{
		Score.Instance.AddPoints(points);
	}
}

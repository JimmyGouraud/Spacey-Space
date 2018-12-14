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
		Debug.Log("First step : wait a positioning destination");
		yield return new WaitUntil(() => Mathf.Abs(positioning.x) < Mathf.Epsilon && Mathf.Abs(positioning.y) < Mathf.Epsilon);

		// Second step : positioning
		Debug.Log("Second step : positioning");
		yield return Positioning();

		// Third step : random movement
		Debug.Log("Third step : random movement");
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

		while (Mathf.Abs(positionDestination.x - transform.position.x) > Mathf.Epsilon && Mathf.Abs(positionDestination.y - transform.position.y) > Mathf.Epsilon) {
			transform.position = Vector2.MoveTowards(transform.position, positionDestination, step);
			yield return null;
		}
	}

	void OnDestroy()
	{
		Score.Instance.AddPoints(points);
	}
}

using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour
{
	public int points = 250; // How much is the enemy worth
	public float speed = 20f;
	public Rigidbody2D rb;

	void OnDestroy()
	{
		Score.Instance.AddPoints(points);
	}

	public void MoveToPos(Vector2 position)
	{
		StartCoroutine(Coroutine_MoveToPos(position));
	}

	IEnumerator Coroutine_MoveToPos(Vector2 position)
	{
		rb.velocity = (position - rb.position).normalized * speed;

		while (true) {
			if (Vector2.SqrMagnitude(position - rb.position) < 0.01f) {
				rb.velocity = Vector2.zero;
				rb.position = position;
			}
			yield return null;
		}
	}

}

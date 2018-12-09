using UnityEngine;


public class Enemy : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			Destroy(this.gameObject);
		}
	}
}

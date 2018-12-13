using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 10f;
	public int damage = 30;
	public Rigidbody2D rb;
	public bool isPlayerBullet;
	
	string targetTag;


	void Start()
	{
		targetTag = isPlayerBullet ? "Enemy" : "Player";
	}

	void FixedUpdate()
	{
		this.transform.position += this.transform.up * this.speed * Time.fixedDeltaTime;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == targetTag) {
			Life life = collision.GetComponent<Life>();
			if (life != null) {
				life.TakeDamage(damage);
			}

			Destroy(this.gameObject);
		}
	}

	// OnBecameInvisible is called when the renderer is no longer visible by any camera.
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}

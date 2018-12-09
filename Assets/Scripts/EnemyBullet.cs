using UnityEngine;


public class EnemyBullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 30;
	public Rigidbody2D rb;

	void Start()
	{
		rb.velocity = this.transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
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

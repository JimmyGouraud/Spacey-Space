using UnityEngine;


public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 30;
	public Rigidbody2D rb;


	void Start () {
		rb.velocity = this.transform.up * speed;	
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") { return; }

		Life life = collision.GetComponent<Life>();
		if (life != null) {
			life.TakeDamage(damage);
		}

		Destroy(this.gameObject);
	}
}

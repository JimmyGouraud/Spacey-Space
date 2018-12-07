using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public float Speed = 5f;
	public int Damages = 100;

	GameObject m_Target;
	LifeManager m_lifeManager;


	void Start()
	{
		m_Target = GameObject.FindGameObjectWithTag("Player");
		m_lifeManager = this.GetComponent<LifeManager>();

		this.GetComponent<Rigidbody>().velocity = Speed * (m_Target.transform.position - this.transform.position).normalized;
	}

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
			case "Bullet":
				m_lifeManager.TakeDamage(other.GetComponent<BulletManager>().Damages);
				break;
			case "Player":
				Destroy(this.gameObject);
				break;
			default:
				break;
		}
	}
}

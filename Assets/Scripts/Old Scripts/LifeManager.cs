using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
	public int MaxHealthPoint = 100;

	int m_healthPoint = 100;


	void Start () {
		m_healthPoint = MaxHealthPoint;
	}

	public void GetHeal(int healPoint)
	{
		if (m_healthPoint == MaxHealthPoint) { return; }

		m_healthPoint += healPoint;

		if (m_healthPoint > MaxHealthPoint) {
			m_healthPoint = MaxHealthPoint;
		}
	}

	public void TakeDamage(int damagePoint)
	{
		m_healthPoint -= damagePoint;

		if (!IsAlive()) {
			Destroy(this.transform.gameObject);
		}
	}

	public bool IsAlive()
	{
		return (m_healthPoint > 0);
	}
}

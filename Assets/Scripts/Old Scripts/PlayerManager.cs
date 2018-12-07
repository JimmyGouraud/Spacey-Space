using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public Camera Camera;

	BulletsShooter m_shooter;
	LifeManager m_lifeManager;


	void Start()
	{
		m_shooter = GetComponentInChildren<BulletsShooter>();
		m_lifeManager = GetComponent<LifeManager>();
		m_shooter.StartShooting();
	}

	void FixedUpdate()
	{
		UpdateOrientation();
	}

	void UpdateOrientation()
	{
		RaycastHit hit;
		Ray ray = this.Camera.ScreenPointToRay(Input.mousePosition);
		int layerMask = 1 << LayerMask.NameToLayer("Terrain");

		if (Physics.Raycast(ray, out hit, 100f, layerMask)) {
			this.transform.LookAt(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
		}
	}

	void OnTriggerEnter(Collider other)
	{
		switch (other.tag) {
			case "Enemy":
				m_lifeManager.TakeDamage(other.GetComponent<EnemyManager>().Damages);
				break;
			default:
				break;
		}
	}
}

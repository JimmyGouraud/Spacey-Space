using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsShooter : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject BulletsSpawned; // Where we instanciate bullets.

	[Range(1.0f, 15.0f)] public float FireRate = 5.0f; // How many time we shoot by seconds.
	[Range(5.0f, 30.0f)] public float BulletSpeed = 20.0f; // How fast are the bullets.


	public void StartShooting()
	{
		StartCoroutine("Shooting");
	}

	public void StopShooting()
	{
		StopCoroutine("Shooting");
	}

	IEnumerator Shooting()
	{
		while (true) {
			Shoot();
			yield return new WaitForSeconds(1 / FireRate);
		}
	}

	void Shoot()
	{
		GameObject bullet = Instantiate(Bullet, this.transform);
		bullet.transform.parent = BulletsSpawned.transform;
		bullet.GetComponent<Rigidbody2D>().velocity = this.transform.up * BulletSpeed;
	}
}

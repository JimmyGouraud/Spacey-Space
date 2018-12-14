using System.Collections;
using UnityEngine;


public class Gun : MonoBehaviour
{
	public GameObject bullet;
	public float fireRate = 0.1f;

	void Start() {
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot()
	{
		while (true) {
			Instantiate(bullet, this.transform.position, this.transform.rotation);
			yield return new WaitForSeconds(fireRate);
		}
	}
}

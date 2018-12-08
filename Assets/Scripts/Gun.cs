using System.Collections;
using UnityEngine;


public class Gun : MonoBehaviour
{
	public GameObject[] firePoint;
	public GameObject bullet;
	public float fireRate = 0.1f;

	void Start() {
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot()
	{
		while (true) {
			foreach (GameObject go in firePoint) {
				Instantiate(bullet, go.transform.position, go.transform.rotation);
			}

			yield return new WaitForSeconds(fireRate);
		}
	}
}

using System.Collections;
using UnityEngine;


public class Gun : MonoBehaviour
{
	public GameObject[] firePoints;
	public GameObject bullet;
	public float fireRate = 0.1f;

	void Start() {
		StartCoroutine(Shoot());
	}

	IEnumerator Shoot()
	{
		while (true) {
			foreach (GameObject go in firePoints) {
				Instantiate(bullet, go.transform.position, go.transform.rotation);
			}

			yield return new WaitForSeconds(fireRate);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsController : MonoBehaviour
{
	public GameObject[] Guns;

	void Start () {
		foreach(GameObject gun in Guns) {
			gun.GetComponent<BulletsShooter>().StartShooting();
		}
	}
	
}

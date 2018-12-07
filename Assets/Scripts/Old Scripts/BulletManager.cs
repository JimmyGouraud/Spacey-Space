using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
	public float Lifetime = 15f;
	public int Damages = 100;


	void Start() {
		Destroy(this.transform.gameObject, Lifetime);
	}
}

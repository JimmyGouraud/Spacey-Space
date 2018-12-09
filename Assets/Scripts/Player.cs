using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy") {
			Destroy(this.gameObject);
		}
	}
}

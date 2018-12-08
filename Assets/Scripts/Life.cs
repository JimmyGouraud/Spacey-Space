using UnityEngine;


public class Life : MonoBehaviour
{
	public int maxHealth = 100;

	int health = 100;


	void Start()
	{
		health = maxHealth;
	}

	public void GetHeal(int healthPoint)
	{
		if (health == maxHealth) { return; }

		health += healthPoint;

		if (health > maxHealth) {
			health = maxHealth;
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (!IsAlive()) {
			// TODO: Instanciate gameobject to simulate death (explosion or something like that)
			Destroy(this.gameObject);
		}
	}

	public bool IsAlive()
	{
		return (health > 0);
	}
}

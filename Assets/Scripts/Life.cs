using UnityEngine;


public class Life : MonoBehaviour
{
	public int nbLife = 1;
	public int maxHealth = 100;

	int health = 100;
	public delegate void UpdateLifeCountDelegate(int nbLife);
	public UpdateLifeCountDelegate UpdateLifeCount;

	void Start()
	{
		health = maxHealth;
		if (UpdateLifeCount != null) {
			UpdateLifeCount(nbLife);
		}
	}

	public void Heal(int healthPoint)
	{
		if (health == maxHealth) { return; }

		health += healthPoint;

		if (health > maxHealth) {
			health = maxHealth;
		}
	}

	public void AddLife(int nbBonusLife)
	{
		nbLife += nbBonusLife;

		if (UpdateLifeCount != null) {
			UpdateLifeCount(nbLife);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (!IsAlive()) {
			nbLife--;
			if (nbLife < 0) {
				nbLife = 0;
			}

			if (UpdateLifeCount != null) {
				UpdateLifeCount(nbLife);
			}

			// TODO: Instanciate gameobject to simulate death (explosion or something like that)
			if (nbLife <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	public bool IsAlive()
	{
		return (health > 0);
	}
}

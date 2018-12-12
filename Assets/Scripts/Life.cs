using UnityEngine;


public class Life : MonoBehaviour
{
	public delegate void UpdateLifeCountDelegate(int _lifes);
	public UpdateLifeCountDelegate UpdateLifesCount;

	public delegate void PlayerDeathDelegate();
	public PlayerDeathDelegate PlayerDeath;

	public int health = 100;

	[SerializeField]
	private int lifes = 1;
	public int LifesCount
	{
		get	{ return lifes; }

		set
		{
			if (UpdateLifesCount != null) {
				UpdateLifesCount(lifes);
			}

			lifes = value;
			if (lifes < 0) {
				lifes = 0;
				if (PlayerDeath != null) {
					PlayerDeath();
				}

				// TODO: Instanciate gameobject to simulate death (explosion or something like that)
				Destroy(this.gameObject);
			}
		}
	}
	

	public void Heal(int healthPoint)
	{
		health += healthPoint;
	}

	public void AddLife(int nbBonusLife)
	{
		LifesCount += nbBonusLife;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (!IsAlive()) {
			LifesCount--;
		}
	}

	public bool IsAlive()
	{
		return (health > 0);
	}
}

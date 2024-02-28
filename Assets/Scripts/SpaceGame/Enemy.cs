using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
	[SerializeField] private float health;
	[SerializeField] private int points;
	[SerializeField] private IntEvent scoreEvent;

	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;
	[SerializeField] private SpawnerPoints spawnerPoints;



	public void ApplyDamage(float damage)
	{
		if (tag == "Spawner")
		{
			spawnerPoints.enableOnAwake = true;
			spawnerPoints.Start();	
		}
		else
		health -= damage;
		if (health <= 0)
		{
			scoreEvent?.RaiseEvent(points);
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null)
			{
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
}

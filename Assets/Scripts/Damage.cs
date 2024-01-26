using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 1;
	[SerializeField] bool oneTime = true;

	private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<Player>(out Player player)) //trygetcomponent idamagable
		{
			player.Damage(damage);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!oneTime && other.gameObject.TryGetComponent<Player>(out Player player))
		{
			player.Damage(damage * Time.deltaTime);
		}
	}
}

public interface IDamagable
{
	void TakeDamage(float damage); //player could derive from interface
}
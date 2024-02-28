using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPickup : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player)) //TryGetComponent<Player>
		{
			player.OnWinGame();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCoins : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] Player player;

	private void OnTriggerEnter(Collider other)
	{
        if (player.Score >= 20)
        {
			animator.SetTrigger("Start");
		}
        
	}
}

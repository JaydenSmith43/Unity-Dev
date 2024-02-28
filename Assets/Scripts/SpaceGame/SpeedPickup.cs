using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject pickupPrefab;
	[SerializeField] PathFollower pathFollower;
	[SerializeField] VoidEvent speedPickupEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out PlayerShip player))
		{
			speedPickupEvent.RaiseEvent();
			pathFollower.speed += speed;
			if (pickupPrefab != null )Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

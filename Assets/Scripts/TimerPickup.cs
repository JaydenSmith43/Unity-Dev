using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPrefab = null;

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player)) //TryGetComponent<Player>
		{
            player.AddTime(5);
        }

        //var player = other.gameObject.GetComponent<Player>(); //then check

        Instantiate(pickupPrefab, transform.position, Quaternion.identity); //identity is pointing down, no rotation
        Destroy(gameObject);
    }
}

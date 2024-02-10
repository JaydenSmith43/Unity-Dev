using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable //interactable
{
	//[SerializeField] private Action action;
	[SerializeField] private PathFollower pathFollower;
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private Inventory inventory;
	[SerializeField] private FloatVariable score;
	[SerializeField] private FloatVariable health;

	[SerializeField] private FloatVariable hitPrefab;
	[SerializeField] private FloatVariable destroyPrefab;

	private void Start()
	{
		scoreEvent.Subscribe(AddPoints);

		//if (action != null)
		//{
		//	action.onEnter += OnInteractStart;
		//	action.onStay += OnInteractActive;
		//}
	}

	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            inventory.StopUse();
        }
		pathFollower.speed = (Input.GetKey(KeyCode.Space)) ? 4 : 2;
    }

	public void AddPoints(int points)
	{
		score.value += points;
		Debug.Log(score.value);
	}

	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		if (health.value <= 0)
		{
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

	public void ApplyHealth(float health)
	{
		this.health.value += health;
		this.health.value = Mathf.Min(this.health.value, 100);
	}
}

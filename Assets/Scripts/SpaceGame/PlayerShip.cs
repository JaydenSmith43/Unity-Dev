using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable //interactable
{
	//[SerializeField] private Action action;
	[SerializeField] private PathFollower pathFollower;
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private Inventory inventory;
	[SerializeField] private float score;
	[SerializeField] private float health;

	[SerializeField] TMP_Text healthUI;
	[SerializeField] TMP_Text ScoreUI;
	[SerializeField] AudioSource healthSound;
	[SerializeField] AudioSource speedSound;
	[SerializeField] AudioSource hitSound;
	[SerializeField] VoidEvent playerDeadEvent;
	//[SerializeField] VoidEvent playerWinEvent;


	[SerializeField] protected GameObject hitPrefab;
	[SerializeField] protected GameObject destroyPrefab;

	private void Start()
	{
		//health = 100;
		healthUI.text = "Health: " + health;
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

		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire3"))
		{
			if (inventory.currentItem == inventory.items[0])
			{
				inventory.currentItem = inventory.items[1];
				inventory.currentItem.Equip();
			}
			else if (inventory.currentItem == inventory.items[1])
			{
				inventory.currentItem = inventory.items[0];
				inventory.currentItem.Equip();
			}
			
		}
		//pathFollower.speed = (Input.GetKey(KeyCode.Space)) ? 4 : 4;
	}

	public void AddPoints(int points)
	{
		score += points;
		ScoreUI.text = "Score: " + score;
	}

	public void ApplyDamage(float damage)
	{
		health -= damage;
		healthUI.text = "Health: " + health;
		hitSound.Play();
		if (health <= 0)
		{
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			playerDeadEvent.RaiseEvent();
			//Destroy(gameObject);
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
		this.health += health;
		this.health = Mathf.Min(this.health, 100);
		healthUI.text = "Health: " + this.health;
		healthSound.Play();
	}

	public void PlaySpeedSFX()
	{
		speedSound.Play();
	}

	public void onStart ()
	{
		health = 100;
		score = 0;
		healthUI.text = "Health: " + health;
		ScoreUI.text = "SCore: " + score;
	}
}

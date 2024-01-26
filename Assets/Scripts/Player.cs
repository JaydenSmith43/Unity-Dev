using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AudioSource coinSound;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
	[SerializeField] IntEvent timerEvent = default;
	[SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;

	private int score = 0;
    private int time = 0;
    public int Score {  
        get { return score; } 
        set { 
            score = value; 
            scoreText.text = score.ToString() + "/20"; 
            scoreEvent.RaiseEvent(time);
        } 
    }

	private void Start()
    {
        //health.value = 5.5f;
    }

	private void OnEnable()
	{
        gameStartEvent.Subscribe(OnStartGame);
	}

	public void AddPoints(int points)
    {
        Score += points;
        coinSound.Play();
    }

	public void AddTime(int time)
	{
		timerEvent.RaiseEvent(time);
	}

	private void OnStartGame()
    {
        characterController.enabled = true;
    }

	public void OnRespawn(GameObject respawn)
	{
		transform.position = respawn.transform.position;
		transform.rotation = respawn.transform.rotation;
        characterController.Reset();
	}

	public void Damage(float damage)
	{
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }
    }
}

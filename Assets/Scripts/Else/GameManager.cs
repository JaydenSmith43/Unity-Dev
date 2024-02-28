using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    //[SerializeField] TMP_Text livesUI;
    //[SerializeField] TMP_Text timerUI;
	//[SerializeField] TMP_Text doorText;

    //[SerializeField] Slider healthUI;
    
    [SerializeField] AudioSource music;

    [SerializeField] FloatVariable health;

    [SerializeField] GameObject respawn;

    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;

	public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
        WIN
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;
    //public const int COIN_MAX = 20;
    //public int Lives { 
    //    get { return lives; } 
    //    set { 
    //        lives = value; 
    //        livesUI.text = "Lives: " + lives.ToString(); 
    //        } 
    //    }

    //public float Timer { 
    //    get { return timer; } 
    //    set {  
    //        timer = value;
    //        //timerUI.text = string.Format("{0:F1}", timer);//Timer.ToString();
    //        timerUI.text = timer.ToString("0.0");
    //    } 
        
    //}

	private void OnEnable()
	{
        //scoreEvent.Subscribe(OnAddPoints);
	}

	private void OnDisable()
	{
		//scoreEvent.Unsubscribe(OnAddPoints);
	}

	void Start()
    {
        //scoreEvent.Subscribe(OnAddPoints);
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:

                titleUI.SetActive(true);
                winUI.SetActive(false);
				loseUI.SetActive(false);
				Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
				winUI.SetActive(false);
				loseUI.SetActive(false);

				timer = 60;
				lives = 3;
				health.value = 10;

				titleUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                music.Play();

                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                //Timer = Timer - Time.deltaTime;
                //if (Timer <= 0)
                //{
                //    print("TIME IS UP!!!");
                //    state = State.GAME_OVER;
                //}
                break;
            case State.GAME_OVER:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				loseUI.SetActive(true);
				break;
            case State.WIN:
				winUI.SetActive(true);
				break;
        }

        //healthUI.value = health.value / 10.0f;
    }

    public void OnStartGame()
    {
        state = State.START_GAME;
    }

	public void OnTitle()
	{
		state = State.TITLE;
	}

	public void OnPlayerDead()
	{
        state = State.GAME_OVER;
        print("i dieded");
    }

	public void OnAddPoints(int points)
    {
        print(points);
        if (points >= 20)
        {
            //print("points above 20!!!");
            //doorText.text = "Touch the red circle to escape!";
        }
    }

	public void OnAddTime(int time)
	{
		print(time + "THIS WAS PRINTED!!");
        timer += time;
	}

    public void OnWin()
    {
        state = State.WIN;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
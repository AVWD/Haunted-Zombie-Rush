using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {
	// Static means there is only one
	public static GameManager instance = null;
	[SerializeField] private GameObject mainMenu;
	private bool gameStarted = false;
	private bool playerActive = false;
	private bool gameOver = false;

	//Getters and setters. 
	//Accessers for other scripts
	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}

	void Awake() {
		if(instance == null){
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad(gameObject);

		Assert.IsNotNull(mainMenu);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerCollided() {
		gameOver = true;
	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void EnterGame() {
		mainMenu.SetActive(false);
		gameStarted = true;

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {
	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;
	
	private Animator anim;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	//Good place to put debug things BEFORE Start function
	void Awake(){
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	private bool jump = false;

	// Use this for initialization
	void Start () {
		//Getting references to our object components
		anim = GetComponent<Animator> (); // Look for specific type of component on the object
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if(!GameManager.instance.GameOver && GameManager.instance.GameStarted){
			if (Input.GetMouseButtonDown(0)){
				GameManager.instance.PlayerStartedGame();
				anim.Play("jump");
				audioSource.PlayOneShot (sfxJump);
				rigidBody.useGravity = true;
				jump = true;
			}
		}
			
	}

	void FixedUpdate() {
		if (jump == true) {
			jump = false;
			rigidBody.velocity = new Vector2 (0,0);
			rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision collision){
		//Created an Obstacle tag for the Rock Prefab
		if(collision.gameObject.tag == "obstacle"){
			rigidBody.AddForce(new Vector2(50,20), ForceMode.Impulse);
			rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
			GameManager.instance.PlayerCollided();
		}
	}
}

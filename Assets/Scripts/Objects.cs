// TODO Creating infinite loop!!!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

	[SerializeField] private float objectSpeed = 1; //Change the time in REALTIME, that is what SerializeField does for you.
	[SerializeField] private float resetPosition = 26.29f;
	[SerializeField] private float startPosition = -117.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		//If the game is over STOP MOVING EVERYTHING
		if(!GameManager.instance.GameOver) {
			transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime)); 
		}

		if(transform.localPosition.x >= resetPosition) {
			Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
			transform.position = newPos;
		}
	}
}

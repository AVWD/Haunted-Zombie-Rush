using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Objects {

	[SerializeField] Vector3 topPos;
	[SerializeField] Vector3 bottomPos;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine(Move(bottomPos));
	}

	protected override void Update() {

	if(GameManager.instance.PlayerActive) {
		base.Update();
	}

	}

	//If we want to pause or move something within certain period of time
	//Like, go up then pause, go down then pause
	//Use IEnumerator
	IEnumerator Move(Vector3 target) {

		while(Mathf.Abs((target - transform.localPosition).y) > 0.20f) {

			Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;

			transform.localPosition += direction * Time.deltaTime * speed;

			yield return null; // Keeps loop running every single cycle
		}

		print ("Reached the target");

		//We've moved and moved, now wait for 5 seconds, then start over again
		yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;

		StartCoroutine(Move(newTarget));
	}
}

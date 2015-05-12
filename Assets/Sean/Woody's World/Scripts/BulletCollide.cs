﻿using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour {
	public GameObject bang;
	public GameObject particles;

	private GameObject creator;
	private bool active;

	// Use this for initialization
	void Start () {
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		Collider other = collision.collider;
		if (other.tag == "Enemy" && active) {
			GameObject.Instantiate (bang, gameObject.transform.position, gameObject.transform.rotation);
			other.GetComponent<CreatureHealth> ().takeDamage (1);
			GetComponent<BulletKill> ().die ();
		} else if (other.tag == "Pull" && active) {
			GetComponent<BulletKill> ().die ();
			creator.GetComponent<PlayerPuller> ().pullTo(other.gameObject);
		}
		Physics.IgnoreCollision (GetComponent<Collider> (), other);
	}

	public void setCreator(GameObject obj){
		creator = obj;
	}
}
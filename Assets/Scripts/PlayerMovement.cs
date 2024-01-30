using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	///////// MAIN VARIABLES /////////
	public float moveSpeed = 5f;
	public float jumpPower = 360f;
	public float dashPower = 7f;

	Rigidbody2D rigidBody;

	float horMovement;

	bool isGrounded = false;

	///////// SETUP /////////
	private void Start() {
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		RespawnAtCheckpoint();
	}

	///////// CONTROLS /////////
	private void Update() {
		//// Horizontal movement
		horMovement = Input.GetAxis("Horizontal");
		if (horMovement < 0 && transform.position.x < 0) {
			horMovement = 0;
		}

		//// Jumping
		if (Input.GetButtonDown("Jump") && isGrounded) {
			isGrounded = false;
			Jump();
		}
		
		//// Falling
		if (transform.position.y < 0) RespawnAtCheckpoint();
	}

	///////// COLLISION /////////
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer == 3) isGrounded = true;
	}

	private void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.layer == 3) isGrounded = false;
	}

	///////// MOVEMENT /////////
	private void FixedUpdate() {
		rigidBody.velocity = new Vector2(horMovement * moveSpeed, rigidBody.velocity.y);
	}

	///////// JUMP /////////
	private void Jump() {
		rigidBody.AddForce(Vector2.up * jumpPower);
	}

	///////// RESPAWN /////////
	public GameObject checkpoint;
	private void RespawnAtCheckpoint() {
		rigidBody.velocity = Vector2.zero;
		transform.position = checkpoint.transform.position;
		isGrounded = false;
	}
}

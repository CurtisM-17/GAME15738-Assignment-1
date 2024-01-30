using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
	public float lifetime = 5f; // How long the projectile lasts
	public Vector3 direction = Vector3.left;
	public float speed = 5f;

	Rigidbody2D rb;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();

		GetComponent<KillBricks>().destroyOnTouch = true; // Destroy the projectile when collided with

		Destroy(gameObject, lifetime); // Self destroy
	}

	private void FixedUpdate() {
		rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
	}
}

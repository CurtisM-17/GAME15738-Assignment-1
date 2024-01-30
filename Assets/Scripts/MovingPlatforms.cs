using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
	/*
	Moving platform that infinitely starts from one position and tweens linearly to another (no delays or pauses)
	*/

	Vector2 firstPos = Vector2.zero;
	public Vector2 secondPos = Vector2.zero;

	public float speed = 0.5f;

	bool toP2 = true; // Whether we're actively lerping to the secondPos or not

	private void Start() {
		firstPos = transform.position; // Start at active position
	}

	private void Update() {
		Vector2 pos = firstPos;
		if (toP2) pos = secondPos;

		Vector2 distFromPos = (Vector2)transform.position - pos;

		transform.Translate(speed * Time.deltaTime * -(distFromPos.normalized));


		if (distFromPos.magnitude <= 0.1) toP2 = !toP2;
	}
}
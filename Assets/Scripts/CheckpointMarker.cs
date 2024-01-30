using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMarker : MonoBehaviour
{
	public GameObject teleportSpot;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.layer != 7) return; // Player only

		collision.gameObject.GetComponent<PlayerMovement>().checkpoint = teleportSpot;
	}
}

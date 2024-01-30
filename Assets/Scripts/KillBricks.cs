using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBricks : MonoBehaviour
{
	public bool destroyOnTouch = false;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.layer != 7) return; // Player only

		collision.gameObject.GetComponent<PlayerMovement>().RespawnAtCheckpoint();

		if (destroyOnTouch) Destroy(gameObject);
	}
}

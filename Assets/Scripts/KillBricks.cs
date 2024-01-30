using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBricks : MonoBehaviour
{
	public PlayerMovement plrScript;

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.layer != 7) return; // Player only

		plrScript.RespawnAtCheckpoint();
	}
}

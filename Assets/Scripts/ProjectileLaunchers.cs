using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunchers : MonoBehaviour
{
	public GameObject barrel;
	public GameObject projectile;
	public float minInterval, maxInterval = 0f; // Minimum & maximum delay between projectiles (seconds)

	float timer = 0f; // Full object lifetime
	float lastProjectile = 0f; // timer position
	float activeInterval = 0f;

	// For the projectile
	public float projLifetime = 5f; // How long the projectile lasts
	public Vector3 projDirection = Vector3.left;
	public float projSpeed = 5f;

	private void Start() {
		GenerateInterval(); // New wait time
	}

	private void FixedUpdate() {
		timer += Time.deltaTime;

		if (timer - lastProjectile >= activeInterval) {
			SpawnProjectile();
		}
	}

	private void SpawnProjectile() {
		/////// Spawn Projectile
		lastProjectile = timer;
		GenerateInterval();

		GameObject proj = Instantiate(projectile, barrel.transform.position, barrel.transform.rotation);

		// Match stats
		Projectiles projScript = proj.GetComponent<Projectiles>();

		projScript.lifetime = projLifetime;
		projScript.direction = projDirection; 
		projScript.speed = projSpeed;
	}

	private void GenerateInterval() {
		//////// Generate new random wait time
		activeInterval = Random.Range(minInterval, maxInterval);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int pointsPerHit = 50;
    Scoreboard scoreboard;

	// Use this for initialization
	void Start ()
    {
        AddBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    private void AddBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        scoreboard.ScoreHit(pointsPerHit);          // Update the total score
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);  // Play death effect
        fx.transform.parent = parent;
        Destroy(gameObject);

    }
}

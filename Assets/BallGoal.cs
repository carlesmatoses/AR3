using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoal : MonoBehaviour
{
	MeshRenderer mr;
	Puntuation puntuation;
	float weight;

	// Start is called before the first frame update
	void Awake()
	{
		mr = GetComponent<MeshRenderer>();
		weight = Random.Range(0.06f, 0.12f);
		float t = Mathf.InverseLerp(0.06f, 0.12f, weight);
		SetColor(Color.Lerp(Color.red, Color.green, t));
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void SetColor(Color color) {
		mr.material.color = color;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Ball")) {
			var rb = other.GetComponent<Rigidbody>();
			if (rb.velocity.y > -0.01f) return;

			Vector3 ballScale = other.transform.localScale;
			float ballSize = ballScale.x; // Assuming the ball is uniformly scaled

			if (Mathf.Approximately(ballSize, weight)) {
				// User receives one point
				Debug.Log("User receives one point");
				puntuation.IncreasePuntuation(1);
			} else {
				// Subtract the difference
				float difference = 1 - Mathf.Abs(ballSize - weight)*(1/0.06);
				Debug.Log($"Subtracting {difference} points");
				puntuation.IncreasePuntuation(difference);
			}

			weight = Random.Range(0.06f, 0.12f);
			float t = Mathf.InverseLerp(0.06f, 0.12f, weight);
			SetColor(Color.Lerp(Color.red, Color.green, t));
			Destroy(other.gameObject);
		}
	}
}

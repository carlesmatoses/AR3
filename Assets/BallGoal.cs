using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoal : MonoBehaviour
{
	MeshRenderer mr;
	
    // Start is called before the first frame update
    void Awake()
    {
        mr = GetComponent<MeshRenderer>();
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
			mr.material.color = Color.green;
		}
	}
}

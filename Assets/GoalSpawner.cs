using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GoalSpawner : MonoBehaviour
{
	List<Transform> goals;
	public Transform goalPrefab;
	
	void Awake() {
		goals = new List<Transform>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToPlanesChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnPlanesChanged(ARPlanesChangedEventArgs changes)
	{
		foreach (var plane in changes.added)
		{
			if (goals.Count >= 3) continue;
			
			var c = plane.center;
			var xt = plane.extents;
			
			var x = Random.Range(c.x - xt.x, c.x + xt.x);
			var z = Random.Range(c.z - xt.y, c.z + xt.y);
			
			Transform ins = Instantiate(goalPrefab, new Vector3(x, c.y, z), Quaternion.identity);
			var goal = ins.GetComponent<BallGoal>();
			//goal.SetColor(Color.red);
			goals.Add(ins);
		}

		foreach (var plane in changes.updated)
		{
			// handle updated planes
		}

		foreach (var plane in changes.removed)
		{
			// handle removed planes
		}
	}

	void SubscribeToPlanesChanged()
	{
		// This is inefficient. You should re-use a saved reference instead.
		var manager = Object.FindObjectOfType<ARPlaneManager>();

		manager.planesChanged += OnPlanesChanged;
	}
	}

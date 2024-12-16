using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceUser : MonoBehaviour
{
	public Transform userCamera;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		var fw = userCamera.position - transform.position;
        var q = Quaternion.LookRotation(-fw);
		transform.rotation = q;
    }
}

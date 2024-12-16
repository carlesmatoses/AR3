using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Renderer ballRenderer;
    private float minScale = 0.06f;
    private float maxScale = 0.12f;

    // Start is called before the first frame update
    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float scale = transform.localScale.x;
        float t = Mathf.InverseLerp(minScale, maxScale, scale);
        Color color = Color.Lerp(Color.red, Color.green, t);
        ballRenderer.material.color = color;
    }


}

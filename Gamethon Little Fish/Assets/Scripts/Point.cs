using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PointManager
{
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }
}

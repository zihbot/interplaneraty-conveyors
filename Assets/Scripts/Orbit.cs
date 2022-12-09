using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Material material;

    private const int GRANULARITY = 360;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = GRANULARITY;
        lineRenderer.startColor = Color.white;
        lineRenderer.loop = true;
        lineRenderer.endColor = Color.white;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.receiveShadows = false;
        lineRenderer.material = material;
        lineRenderer.widthMultiplier = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 segmentPosition = transform.position + new Vector3(1, 0, 0);
            Quaternion rotation = Quaternion.Euler(0, i, 0);
            lineRenderer.SetPosition(i, rotation * segmentPosition);
        }
    }
}

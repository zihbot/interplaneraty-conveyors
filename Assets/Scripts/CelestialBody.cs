using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float massInEM; // in solar mass
    public Vector3 posInLd; // in astronomical unit

    //Test
    public Vector3 velocityInLdS; // in astronomical unit
    private LineRenderer lineRenderer;
    public float e;
    public float p;
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 10;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.receiveShadows = false;
        lineRenderer.material = gameObject.GetComponent<Material>();
        lineRenderer.widthMultiplier = 0.01f;
    }

    void Update()
    {
        Orbit o = new Orbit();
        o.gravitationalCenter = this;
        o.relativePositionInLd = new Vector3(1, 0, 0);
        o.velocityInLdS = velocityInLdS;

        e = o.eccentricity.magnitude;
        p = o.parameterInLd;

        ConicSection cs = o.orbitCurve;
        for (int i = 0; i < 10; i++)
        {
            Vector2 linePoint = cs.getCurvePoint((i - 5.0f) / 5.0f);
            lineRenderer.SetPosition(i, new Vector3(linePoint.x, 0, linePoint.y));
        }
    }
}

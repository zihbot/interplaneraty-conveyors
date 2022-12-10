using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public CelestialBody gravitationalCenter;
    public Vector3 posInLd; // in lunar distance

    public Vector3 velocityInKmS; // in astronomical unit
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

    // Update is called once per frame
    void Update()
    {
        Orbit o = new Orbit();
        o.gravitationalCenter = gravitationalCenter;
        o.relativePositionInLd = posInLd - gravitationalCenter.posInLd;
        o.velocityInLdS = velocityInKmS / 384400.0f;

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

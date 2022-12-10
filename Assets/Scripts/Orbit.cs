using UnityEngine;

public class Orbit
{

    // Gravitational constant in lunar distance ^ 3 / earth mass
    // gravitational constant * earth mass / 384400000^3
    private static readonly float GRAVITATIONAL_CONSTANT_IN_CUSTOM_UNITS = 7.01760958f * Mathf.Pow(10, -12);

    public CelestialBody gravitationalCenter;
    public Vector3 center
    {
        get { return gravitationalCenter.gameObject.transform.position; }
    }
    public Vector3 relativePositionInLd;
    public Vector3 velocityInLdS;

    public Vector3 eccentricity // e
    {
        get
        {
            float gravitationalParameterPerAu = gravitationalCenter.massInEM * GRAVITATIONAL_CONSTANT_IN_CUSTOM_UNITS;
            Vector3 angularMomentum = Vector3.Cross(relativePositionInLd, velocityInLdS);
            return Vector3.Cross(velocityInLdS, angularMomentum) / gravitationalParameterPerAu - relativePositionInLd.normalized;
        }
    }
    public float parameterInLd // p
    {
        get
        {
            float gravitationalParameterPerAu = gravitationalCenter.massInEM * GRAVITATIONAL_CONSTANT_IN_CUSTOM_UNITS;
            Vector3 angularMomentum = Vector3.Cross(relativePositionInLd, velocityInLdS);
            return angularMomentum.sqrMagnitude / gravitationalParameterPerAu;
        }
    }

    public ConicSection orbitCurve
    {
        get { return new ConicSection(eccentricity.magnitude, parameterInLd); }
    }
}
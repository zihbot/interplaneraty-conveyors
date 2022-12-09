using UnityEngine;

public class Orbit
{
    public CelestialBody gravitationalCenter;
    public Vector3 center
    {
        get { return gravitationalCenter.gameObject.transform.position; }
    }
    public Vector3 relativePositionInAU;
    public Vector3 velocityInKmS;

    public Vector3 eccentricity // e
    {
        get
        {
            float gravitationalParameterPerAu = gravitationalCenter.massInEM * 0.00266448898f; // gravitational constant * earth mass / astronomical unit / 1000000
            Vector3 angularMomentum = Vector3.Cross(relativePositionInAU, velocityInKmS);
            return Vector3.Cross(velocityInKmS, angularMomentum) / gravitationalParameterPerAu - relativePositionInAU.normalized;
        }
    }
    public float parameter // p
    {
        get
        {
            float gravitationalParameterPerAu = gravitationalCenter.massInEM * 1.78110087f * Mathf.Pow(10,-14); // gravitational constant * earth mass / astronomical unit / astronomical unit / 1000000
            Vector3 angularMomentum = Vector3.Cross(relativePositionInAU, velocityInKmS);
            return angularMomentum.sqrMagnitude / gravitationalParameterPerAu / 149597871000.0f;
        }
    }

    public ConicSection orbitCurve {
        get { return new ConicSection(eccentricity.magnitude, parameter); }
    }
}
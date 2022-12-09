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
            float gravitationalParameterPerAu = gravitationalCenter.massInSM * 887.435768f; // gravitational constant * solar mass / astronomical unit / 1000000
            Vector3 angularMomentum = Vector3.Cross(relativePositionInAU, velocityInKmS);
            return Vector3.Cross(velocityInKmS, angularMomentum) / gravitationalParameterPerAu - relativePositionInAU.normalized;
        }
    }
}
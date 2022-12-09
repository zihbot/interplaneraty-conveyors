using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float massInSM; // in solar mass
    public Vector3 posInAu; // in astronomical unit

    //Test
    public Vector3 velocityInKmS; // in astronomical unit

    public float eccentricity; // in solar mass

    void Update()
    {
        Orbit o = new Orbit();
        o.gravitationalCenter = this;
        o.relativePositionInAU = new Vector3(1, 0, 0);
        o.velocityInKmS = velocityInKmS;
        eccentricity = o.eccentricity.magnitude;
    }
}

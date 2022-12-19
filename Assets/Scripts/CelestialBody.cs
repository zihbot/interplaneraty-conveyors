using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float massInEM; // in solar mass
    public Vector3 posInLd; // in lunar distance
    public float radiusInMm; // in mega meter

    public bool central = false;

    void Start()
    {
        SpacePerspectiveHandler.Instance.OnPerspectiveChanged += UpdatePostion;
    }

    void Update()
    {
        if (central) {
            SpacePerspectiveHandler.Instance.UpdateCentralBody(this);
        }
    }

    public void UpdatePostion() {
        gameObject.transform.position = SpacePerspectiveHandler.Instance.PositionToGamePerpective(posInLd);
        float scale = SpacePerspectiveHandler.Instance.ScaleToGamePerpective(this);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }
}

using UnityEngine;

public class SpacePerspectiveHandler
{
    public static readonly float LUNAR_DISTANCE_IN_METERS = 384400000.0f;

    public delegate void PerspectiveChanged();
    public event PerspectiveChanged OnPerspectiveChanged;

    private CelestialBody centralBody;

    private static SpacePerspectiveHandler _instance;
    public static SpacePerspectiveHandler Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SpacePerspectiveHandler();
            return _instance;
        }
    }

    public void UpdateCentralBody(CelestialBody centralBody)
    {
        if (this.centralBody == centralBody) return;
        this.centralBody = centralBody;
        this.centralBody.gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (OnPerspectiveChanged != null)
        {
            OnPerspectiveChanged();
        }
    }

    public Vector3 PositionToGamePerpective(CelestialBody body) {
        return PositionToGamePerpective(body.posInLd);
    }

    public Vector3 PositionToGamePerpective(Vector3 positionInWorldInLd)
    {
        if (centralBody == null)
        {
            return positionInWorldInLd.normalized * 10;
        }
        return (centralBody.posInLd - positionInWorldInLd).normalized * 10;
    }
    public float ScaleToGamePerpective(CelestialBody body)
    {
        if (centralBody == null)
        {
            return 1;
        }
        float distanceInMm = (centralBody.posInLd - body.posInLd).magnitude * (LUNAR_DISTANCE_IN_METERS / 1000000.0f);
        float distanceInCentralRadius = distanceInMm / centralBody.radiusInMm;
        float radiusInCentralRadius = body.radiusInMm / centralBody.radiusInMm;
        float distanceInGamePerspective = (body.gameObject.transform.position - centralBody.gameObject.transform.position).magnitude;
        return radiusInCentralRadius * distanceInGamePerspective / distanceInCentralRadius;
    }
}
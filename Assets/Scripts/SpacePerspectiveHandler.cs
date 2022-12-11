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
        if (OnPerspectiveChanged != null)
        {
            OnPerspectiveChanged();
        }
    }

    public Vector3 PositionToGamePerpective(Vector3 positionInWorldInLd)
    {
        if (centralBody == null)
        {
            return positionInWorldInLd.normalized * 10;
        }
        return (centralBody.posInLd - positionInWorldInLd).normalized * 10;
    }
}
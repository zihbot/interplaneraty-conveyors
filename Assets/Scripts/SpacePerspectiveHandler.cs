using UnityEngine;

public class SpacePerspectiveHandler
{
    public static readonly float LUNAR_DISTANCE_IN_METERS = 384400000.0f;

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


}
using UnityEngine;

public class ConicSection
{
    private enum SectionType
    {
        CIRCLE, ELLIPSE, PARABOLA, HYPERBOLA
    }
    float eccentricity;
    float parameter;

    float a;
    float b;
    SectionType type;
    public ConicSection(float eccentricity, float parameter)
    {
        this.eccentricity = eccentricity;
        this.parameter = parameter;

        if (eccentricity < Mathf.Epsilon)
        {
            type = SectionType.CIRCLE;
            a = parameter;
        }
        else if (Mathf.Abs(eccentricity - 1) < Mathf.Epsilon)
        {
            type = SectionType.PARABOLA;
            a = parameter / 2;
        }
        else if (eccentricity > 0 && eccentricity < 1)
        {
            type = SectionType.ELLIPSE;
            a = parameter / (1 - eccentricity * eccentricity);
            b = a * Mathf.Sqrt(1 - eccentricity * eccentricity);
        }
        else
        {
            type = SectionType.HYPERBOLA;
            a = parameter / (eccentricity * eccentricity - 1);
            b = a * Mathf.Sqrt(eccentricity * eccentricity - 1);
        }
    }

    public Vector2 getCurvePoint(float t)
    {
        switch (type)
        {
            case SectionType.CIRCLE:
                return new Vector2(a * Mathf.Cos(t), a * Mathf.Sin(t));
            case SectionType.ELLIPSE:
                return new Vector2(a * Mathf.Cos(t), b * Mathf.Sin(t));
            case SectionType.PARABOLA:
                return new Vector2(a * t * t, 2 * a * t);
            case SectionType.HYPERBOLA:
            default:
                return new Vector2(a / Mathf.Cos(t), b * Mathf.Sin(t));
        }
    }
}
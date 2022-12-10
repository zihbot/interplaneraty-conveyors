using UnityEngine;

public class ConicSection
{
    private enum SectionType
    {
        CIRCLE, ELLIPSE, PARABOLA, HYPERBOLA
    }
    float eccentricity;
    float parameterInLd;

    float a;
    float b;
    SectionType type;
    public ConicSection(float eccentricity, float parameterInLd)
    {
        this.eccentricity = eccentricity;
        this.parameterInLd = parameterInLd;

        if (eccentricity < Mathf.Epsilon)
        {
            type = SectionType.CIRCLE;
            a = this.parameterInLd;
        }
        else if (Mathf.Abs(eccentricity - 1) < Mathf.Epsilon)
        {
            type = SectionType.PARABOLA;
            a = this.parameterInLd / 2;
        }
        else if (eccentricity > 0 && eccentricity < 1)
        {
            type = SectionType.ELLIPSE;
            a = this.parameterInLd / (1 - eccentricity * eccentricity);
            b = a * Mathf.Sqrt(1 - eccentricity * eccentricity);
        }
        else
        {
            type = SectionType.HYPERBOLA;
            a = this.parameterInLd / (eccentricity * eccentricity - 1);
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
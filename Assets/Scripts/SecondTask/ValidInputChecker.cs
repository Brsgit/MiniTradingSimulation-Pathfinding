using System.Collections.Generic;
using UnityEngine;

public class ValidInputChecker 
{
    public bool IsPointInsideRectangles(Vector2 point, IEnumerable<Rectangle> rectangles)
    {
        foreach (Rectangle rectangle in rectangles)
        {
            if (IsPointInsideRectangle(point, rectangle))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsPointInsideRectangle(Vector2 point, Rectangle rectangle)
    {
        return point.x >= rectangle.Min.x && point.x <= rectangle.Max.x &&
               point.y >= rectangle.Min.y && point.y <= rectangle.Max.y;
    }
}

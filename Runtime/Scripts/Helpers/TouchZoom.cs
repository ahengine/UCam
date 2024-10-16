using UnityEngine;

public static class TouchZoom
{
    public static float Pinch()
    {
        if (Input.touchCount != 2)
            return 0;

        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
        Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
        float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;

        Vector2 touchDelta = touch0.position - touch1.position;
        float touchDeltaMag = touchDelta.magnitude;

        return prevTouchDeltaMag - touchDeltaMag;
    }
}


public class TouchDragHandler
{
    public float ValueMultiplier = .4f;
    public float MinDragSize = 10;
    private Vector2 start;
    public Vector2 Current {private set; get; }

    private bool StartDragging;

    public Vector2 UpdateDistance()
    {
        if(Input.GetMouseButtonDown(0))
            {
                start = Input.mousePosition;
                StartDragging = false;
            }

        if(!StartDragging) 
        {
            if(Vector2.Distance(start,(Vector2)Input.mousePosition) < MinDragSize)
            {
                Current = Input.mousePosition;
                return Vector2.zero;
            }

            StartDragging = true;
        }
        Vector2 distance = (Vector2)Input.mousePosition - Current;
        Current = Input.mousePosition; 
        //if(distance.x != 0) Debug.Log((distance*ValueMultiplier).x);
        return distance*ValueMultiplier;
    }

    public Vector2 UpdateDistanceReverseValue()
    {
        Vector2 distance = UpdateDistance();
        return new Vector2(distance.y, distance.x);
    }
}

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

using UnityEngine;

namespace UCAM.Modules
{
    public class ZoomModule : UCamModule
    {
        [SerializeField] private Vector2 limit = new Vector2(45, 60);
        [field:SerializeField] public float Current { private set; get; }
        [SerializeField] private float speed = 3;

        public override void Process()
        {
            base.Process();

            if (owner.IsMobile)
                PinchingTouchDevice();
            else
                MouseDevice();

            owner.Cam.fieldOfView = Current;
        }

        private void PinchingTouchDevice()
        {
            if (Input.touchCount <= 1)
                return;

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                float prevDist = Vector2.Distance(touchZero.position - touchZero.deltaPosition, touchOne.position - touchOne.deltaPosition);
                float dist = Vector2.Distance(touchZero.position, touchOne.position);

                Current = Mathf.Clamp(owner.Cam.fieldOfView * (prevDist / dist), limit.x, limit.y);
            }
        }

        private void MouseDevice() =>
            Current = Mathf.Clamp(Current + Input.mouseScrollDelta.y * speed * Time.deltaTime, limit.x, limit.y);
    }
}

using UCAM.Modules;
using UnityEngine;

namespace UCAM.States
{
    public class RTSState : CameraStateBase
    {
        [SerializeField] private float angle = 45.0f;
        [SerializeField] private float moveSpeed = 10.0f;
        [SerializeField] private float smoothTime = 0.3f;
        private Vector3 previousMousePosition;
        private bool isDragging = false;
        private Vector3 targetPosition;
        private LimitModule limitModule;
        [SerializeField] private Vector3 velocity = Vector3.zero;

        public override void Enter()
        {
            base.Enter();
            owner.GetModule<ZoomModule>().DoActivate();
            (limitModule = owner.GetModule<LimitModule>()).DoActivate();

            targetPosition = owner.Tr.position;
        }
        public override void Exit()
        {
            base.Exit();
            owner.GetModule<ZoomModule>().DoDeactivate();
            limitModule.DoDeactivate();
        }

        public override void Updates()
        {
            base.Updates();
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            if (Input.touchCount != 1)
                return;

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                if (!isDragging)
                {
                    previousMousePosition = mousePosition;
                    isDragging = true;
                }
                else
                {
                    Vector3 mousePositionDelta = mousePosition - previousMousePosition;
                    previousMousePosition = mousePosition;

                    Vector3 cameraPositionDelta = new Vector3(mousePositionDelta.x, 0.0f, mousePositionDelta.y) * moveSpeed * Time.deltaTime;
                    targetPosition -= cameraPositionDelta;
                    targetPosition = limitModule.Apply(targetPosition);
                }
            }
            else
                isDragging = false;

            owner.Tr.position = Vector3.SmoothDamp(owner.Tr.position, targetPosition, ref velocity, smoothTime);
            owner.CamTr.eulerAngles = Vector3.Lerp(owner.CamTr.eulerAngles, new Vector3(angle, 0, 0), smoothTime);
        }
    }
}
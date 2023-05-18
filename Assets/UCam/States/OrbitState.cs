using UnityEngine;
using UCAM.Modules;

namespace UCAM.States
{
    public class OrbitState : CameraStateBase
    {
        [SerializeField] private float lookAngle = 45;
        [SerializeField] private float smoothTime = 45;
        [SerializeField] private float speed = 120.0f;
        [SerializeField] private Transform target;

        private float eulerX;

        private Vector3 desiredPosition = Vector3.zero;
        private Vector3 smoothVelocity = Vector3.zero;

        public void SetTarget(Transform target) =>
            this.target = target;

        public override void Enter()
        {
            base.Enter();
            owner.GetModule<ZoomModule>().DoActivate();
            eulerX = 0;
        }
        public override void Exit()
        {
            base.Exit();
            owner.GetModule<ZoomModule>().DoActivate();
        }
        public override void Updates()
        {
            base.Updates();

            const string MouseX = "Mouse X";

            eulerX += (Input.GetMouseButton(0) ? Input.GetAxis(MouseX) : 0) * speed * Time.deltaTime;
            desiredPosition = Quaternion.Euler(lookAngle, eulerX, 0) * target.position;
            owner.Tr.position = Vector3.SmoothDamp(owner.CamTr.position, desiredPosition, ref smoothVelocity, smoothTime);
        }
    }
}

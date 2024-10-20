using UnityEngine;

namespace UCamSystem.Modules
{
    public class OrbitModule : UCamModuleGeneric<OrbitModuleData>
    {
        public override void Active()
        {
            base.Active();
            Look();
        }

        public override void Update()
        {
            base.Update();

            if (!Input.GetMouseButton(0) || owner.IsLocked)
                return;

            Dragging();
            Look();
        }

        private void Dragging()
        {
            float YAxis = state.RotationY ? Input.GetAxis(Constants.MouseX) : 0;
            float XAxis = state.RotationX ? Input.GetAxis(Constants.MouseY) : 0;

            Quaternion camAngleY = Quaternion.AngleAxis(YAxis * state.MouseSpeed, Vector3.up);
            owner.TargetOffset = camAngleY * owner.TargetOffset;

            if(!state.RotationX)
                return;

            Vector3 targetDirection = owner.TargetOffset.normalized;
            float currentXAngle = Mathf.Asin(targetDirection.y) * Mathf.Rad2Deg;
            float newXAngle = Mathf.Clamp(currentXAngle + XAxis * state.MouseSpeed,
                                             state.RotationXLimit.x, state.RotationXLimit.y);
            float xRotationDelta = newXAngle - currentXAngle;
            Quaternion camAngleX = Quaternion.AngleAxis(xRotationDelta, owner.Ghost.Tr.right);
            owner.TargetOffset = camAngleX * owner.TargetOffset;
        }


        private void Look()
        {
            Vector3 newPos = owner.Target.position + owner.TargetOffset;
            owner.Ghost.Tr.position = newPos;
            owner.Ghost.Tr.LookAt(owner.Target);
        }
    }
}
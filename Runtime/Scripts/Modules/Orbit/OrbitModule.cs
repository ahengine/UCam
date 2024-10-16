using UnityEngine;

namespace UCamSystem.Modules
{
    public class OrbitModule : UCamModuleGeneric<OrbitModuleData>
    {
        public override void Update()
        {
            base.Update();

            if (!Input.GetMouseButton(0) || owner.IsLocked)
                return;

            Dragging();

            Vector3 newPos = owner.Target.position + owner.TargetOffset;
            owner.Ghost.transform.position = newPos;
            owner.Ghost.transform.LookAt(owner.Target);
        }

        private void Dragging()
        {
            float YAxis = state.RotationY ? Input.GetAxis(Constants.MouseX) : 0;
            float XAxis = state.RotationX ? Input.GetAxis(Constants.MouseY) : 0;

            // Y-axis rotation
            Quaternion camAngleY = Quaternion.AngleAxis(YAxis * state.MouseSpeed, Vector3.up);
            owner.TargetOffset = camAngleY * owner.TargetOffset;

            // X-axis rotation
            XAxis = Mathf.Clamp(XAxis, state.RotationXLimit.x, state.RotationXLimit.y);
            Quaternion camAngleX = Quaternion.AngleAxis(XAxis * state.MouseSpeed, Vector3.right);
            owner.TargetOffset = camAngleX * owner.TargetOffset;
        }
    }
}
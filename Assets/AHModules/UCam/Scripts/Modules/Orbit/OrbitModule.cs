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
            float mouseX = state.RotationX ? Input.GetAxis(Constants.MouseX) : 0;
            float mouseY = state.RotationY ? Input.GetAxis(Constants.MouseY) : 0;

            // Y-axis rotation
            Quaternion camAngleY = Quaternion.AngleAxis(mouseX * state.MouseSpeed, Vector3.up);
            owner.TargetOffset = camAngleY * owner.TargetOffset;

            // X-axis rotation
            Quaternion camAngleX = Quaternion.AngleAxis(mouseY * state.MouseSpeed, Vector3.right);
            owner.TargetOffset = camAngleX * owner.TargetOffset;
        }
    }
}
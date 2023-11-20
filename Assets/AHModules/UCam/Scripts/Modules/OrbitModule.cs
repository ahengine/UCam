using UnityEngine;

namespace UCamSystem.Modules
{
    public class OrbitModule : UCamModule
    {
        private const string MouseX = "Mouse X";   

        [SerializeField] private float rotationSpeedMouse = 5;

        public override void Updates()
        {
            base.Updates();

            if (!Input.GetMouseButton(0) || owner.CantAction)
                return;

            Quaternion camAngle = Quaternion.AngleAxis(Input.GetAxis(MouseX) * rotationSpeedMouse, Vector3.up);
            owner.TargetOffset = camAngle * owner.TargetOffset;
            Vector3 newPos = owner.Target.position + owner.TargetOffset;
            owner.Tr.position = newPos;
            owner.Tr.LookAt(owner.Target);
        }

        public void Set(float rotationSpeedMouse) =>
            this.rotationSpeedMouse = rotationSpeedMouse;
    }
}
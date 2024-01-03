using UnityEngine;

namespace UCamSystem.Modules
{
    public class OrbitModule : UCamModule
    {
        [SerializeField] private OrbitModuleCard stateCard;

        public override void Updates()
        {
            base.Updates();

            if (!Input.GetMouseButton(0) || owner.CantAction)
                return;

            Dragging();

            Vector3 newPos = owner.Target.position + owner.TargetOffset;
            owner.Tr.position = newPos;
            owner.Tr.LookAt(owner.Target);
        }

        private void Dragging()
        {
            float mouseX = stateCard.RotationDirection.Y ? Input.GetAxis(Constants.MouseX) : 0;
            float mouseY = stateCard.RotationDirection.X ? Input.GetAxis(Constants.MouseY) : 0;

            // Y-axis rotation
            Quaternion camAngleY = Quaternion.AngleAxis(mouseX * stateCard.MouseSpeed, Vector3.up);
            owner.TargetOffset = camAngleY * owner.TargetOffset;

            // X-axis rotation
            Quaternion camAngleX = Quaternion.AngleAxis(mouseY * stateCard.MouseSpeed, Vector3.right);
            owner.TargetOffset = camAngleX * owner.TargetOffset;
        }

        public void Set(OrbitModuleCard stateCard) =>
            this.stateCard = stateCard;
    }
}
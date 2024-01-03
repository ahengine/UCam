using UnityEngine;

namespace UCamSystem.Modules
{
    public class FirstPersonModule : UCamModule
    {
        [SerializeField] private FirstPersonModuleCard state;
        private Vector3 rotAround;

        public override void Active()
        {
            base.Active();
            rotAround = state.Space == Space.World ? owner.Tr.eulerAngles : 
                                                     owner.Tr.localEulerAngles;
        }

        public override void Updates()
        {
            if (Input.GetMouseButton(0) && !owner.CantAction)
                rotAround += new Vector3((state.RotationDirection.X ?1:0) * Input.GetAxis(Constants.MouseY) * state.Sensitivity,
                                         (state.RotationDirection.Y ?1:0) * Input.GetAxis(Constants.MouseX) * state.Sensitivity);
            ApplyLimitation();

            switch(state.Space)
            {
                case Space.World:
                    owner.Tr.rotation = Quaternion.Euler(rotAround);
                    break;
                case Space.Self:
                    owner.Tr.localRotation = Quaternion.Euler(rotAround);
                    break;
            }

        }

        private void ApplyLimitation()
        {
            rotAround = new Vector3(
                state.RotationLimit.limitX ? Mathf.Clamp(rotAround.x, state.RotationLimit.limitXRange.x, state.RotationLimit.limitXRange.y) : rotAround.x,
                state.RotationLimit.limitY ? Mathf.Clamp(rotAround.y, state.RotationLimit.limitYRange.x, state.RotationLimit.limitYRange.y) : rotAround.y,
                state.RotationLimit.limitZ ? Mathf.Clamp(rotAround.z, state.RotationLimit.limitZRange.x, state.RotationLimit.limitZRange.y) : rotAround.z
            );
        }

        public void Set(FirstPersonModuleCard stateCard) =>
            state = stateCard;
    }
}
using UnityEngine;

namespace UCamSystem.Modules
{
    public class FirstPersonModule : UCamModuleGeneric<FirstPersonModuleData>
    {
        private Vector3 rotAround;

        public override void Active()
        {
            base.Active();
            rotAround = owner.Ghost.GetEuler(state.Space);
        }

        public override void Update()
        {
            if (Input.GetMouseButton(0) && !owner.IsLocked)
                rotAround += new Vector3((state.RotationX.Enable ?1:0) * Input.GetAxis(Constants.MouseY) * state.Sensitivity,
                                         (state.RotationY.Enable ?1:0) * Input.GetAxis(Constants.MouseX) * state.Sensitivity);
            ApplyLimitation();
            owner.Ghost.SetRotation(Quaternion.Euler(rotAround) ,state.Space);
        }

        private void ApplyLimitation()
        {
            rotAround = new Vector3(
                state.RotationX.Limit.Enable ? state.RotationX.Limit.Clamp(rotAround.x) : rotAround.x,
                state.RotationY.Limit.Enable ? state.RotationY.Limit.Clamp(rotAround.y) : rotAround.y,
                state.RotationLimitZ.Enable  ? state.RotationLimitZ.Clamp(rotAround.z)  : rotAround.z
            );
        }
    }
}
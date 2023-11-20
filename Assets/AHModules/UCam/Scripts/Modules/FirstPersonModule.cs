using UnityEngine;

namespace UCamSystem.Modules
{
    public class FirstPersonModule : UCamModule
    {
        private const string MouseX = "Mouse X";
        [SerializeField] private float Ysensitivity = 5;
        private float rotAroundY;

        public override void Active()
        {
            base.Active();
            rotAroundY = owner.Tr.eulerAngles.y;
        }

        public override void Updates() 
        {
            if(Input.GetMouseButton(0) && !owner.CantAction)
                rotAroundY += Input.GetAxis(MouseX) * Ysensitivity;
            owner.Tr.rotation = Quaternion.Euler(owner.Tr.eulerAngles.x, rotAroundY, owner.Tr.eulerAngles.z);
        }

        public void Set(float value) =>
            Ysensitivity = value;
    }
}
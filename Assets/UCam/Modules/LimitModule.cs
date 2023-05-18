using UnityEngine;

namespace UCAM.Modules
{
    public class LimitModule : UCamModule
    {
        [SerializeField] private Vector2 limitX = new Vector2(-50, 50);
        [SerializeField] private Vector2 limitZ = new Vector2(-50, 50);

        public Vector3 Apply(Vector3 value)
        {
            value.x = Mathf.Clamp(value.x, limitX.x, limitX.y);
            value.z = Mathf.Clamp(value.z, limitZ.x, limitZ.y);
            return value;
        }

        public override void Process()
        {
            base.Process();

            owner.Tr.position = Apply(owner.Tr.position);
        }
    }
}
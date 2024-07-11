using UnityEngine;

namespace UCamSystem.Modules
{
    public class ZoomModule : UCamModuleGeneric<ZoomModuleData>
    {
        private const string MouseScrollWheel = "Mouse ScrollWheel";

        private float zoomAmountMouse = 0;
        private float maxToClampMouse = 10;

        public override void Active()
        {
            base.Active();
            zoomAmountMouse = 0;
        }

        public override void Update()
        {       
            base.Update();

            float wheelMouse = Input.touchCount == 2 ? TouchZoom.Pinch() :Input.GetAxis(MouseScrollWheel);
            float zoomAmountMouseUpdated =zoomAmountMouse + wheelMouse;

            if (wheelMouse < 0 && Vector3.Distance(owner.Ghost.transform.position, owner.Target.position) > state.RangeDistance.y ||
               wheelMouse > 0 && Vector3.Distance(owner.Ghost.transform.position, owner.Target.position) < state.RangeDistance.x)
                return;
            
            zoomAmountMouse = zoomAmountMouseUpdated;
            zoomAmountMouse = Mathf.Clamp(zoomAmountMouse, -maxToClampMouse, maxToClampMouse);
            var translate = Mathf.Min(Mathf.Abs( wheelMouse), maxToClampMouse - Mathf.Abs(zoomAmountMouse));
            translate *= state.Scale * Mathf.Sign(wheelMouse);
            owner.Ghost.transform.Translate(0,0,translate);
            owner.SetDefaultTargetOffset();
        }
    }
}
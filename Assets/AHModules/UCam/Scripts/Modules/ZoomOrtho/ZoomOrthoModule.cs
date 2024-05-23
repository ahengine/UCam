using UnityEngine;

namespace UCamSystem.Modules
{
    public class ZoomOrthoModule : UCamModuleGeneric<ZoomOrthoModuleData>
    {
        private const string MouseScrollWheel = "Mouse ScrollWheel";
        private float _zoomAmountMouse = 0;
        private float _maxToClampMouse = 10;

        public override void Active()
        {
            base.Active();
            _zoomAmountMouse = 0;
        }

        public override void Update()
        {
            base.Update();

            float GetMouseWheel() => Input.touchCount == 2 ? TouchZoom.Pinch() : Input.GetAxis(MouseScrollWheel);

            float _zoomAmountMouseUpdated = _zoomAmountMouse + GetMouseWheel();

            if (GetMouseWheel() < 0 && Vector3.Distance(owner.Ghost.transform.position, owner.Target.position) > state.RangeDistance.y ||
               GetMouseWheel() > 0 && Vector3.Distance(owner.Ghost.transform.position, owner.Target.position) < state.RangeDistance.x)
                return;

            _zoomAmountMouse = _zoomAmountMouseUpdated;
            _zoomAmountMouse = Mathf.Clamp(_zoomAmountMouse, -_maxToClampMouse, _maxToClampMouse);
            var translate = Mathf.Min(Mathf.Abs(GetMouseWheel()), _maxToClampMouse - Mathf.Abs(_zoomAmountMouse));
            translate *= state.Scale * Mathf.Sign(GetMouseWheel());
            owner.Ghost.transform.Translate(0, 0, translate);
            owner.SetDefaultTargetOffset();
        }
    }
}
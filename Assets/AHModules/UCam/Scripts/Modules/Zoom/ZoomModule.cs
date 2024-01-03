using UnityEngine;

namespace UCamSystem.Modules
{
    public class ZoomModule : UCamModule
    {
        private const string MouseScrollWheel = "Mouse ScrollWheel";

        [SerializeField] private ZoomModuleCard stateCard;
        private float _zoomAmountMouse = 0;
        private float _maxToClampMouse = 10;

        public override void Active()
        {
            base.Active();
            _zoomAmountMouse = 0;
        }

        public override void Updates()
        {       

            float GetMouseWheel() => Input.touchCount == 2 ? TouchZoom.Pinch() :Input.GetAxis(MouseScrollWheel);

            float _zoomAmountMouseUpdated =_zoomAmountMouse + GetMouseWheel();

            if (GetMouseWheel() < 0 && Vector3.Distance(owner.Tr.position, owner.Target.position) > stateCard.RangeDistance.y ||
               GetMouseWheel() > 0 && Vector3.Distance(owner.Tr.position, owner.Target.position) < stateCard.RangeDistance.x)
                return;
            
            _zoomAmountMouse = _zoomAmountMouseUpdated;
            _zoomAmountMouse = Mathf.Clamp(_zoomAmountMouse, -_maxToClampMouse, _maxToClampMouse);
            var translate = Mathf.Min(Mathf.Abs( GetMouseWheel()), _maxToClampMouse - Mathf.Abs(_zoomAmountMouse));
            translate *= stateCard.Scale * Mathf.Sign( GetMouseWheel());
            owner.Tr.Translate(0,0,translate);
            owner.SetDefaultTargetOffset();
        }

        public void Set(ZoomModuleCard stateCard) =>
            this.stateCard = stateCard;
    }
}
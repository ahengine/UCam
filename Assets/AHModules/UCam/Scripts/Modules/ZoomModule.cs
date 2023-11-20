using UnityEngine;

namespace UCamSystem.Modules
{
    public class ZoomModule : UCamModule
    {
        private const string MouseScrollWheel = "Mouse ScrollWheel";

        [SerializeField] private float zoomScale = 10;
        [SerializeField] private Vector2 zoomDistance = new Vector2(10, 20);
        private float _zoomAmountMouse = 0;
        private float _maxToClampMouse = 10;

        public override void Updates()
        {
            float _zoomAmountMouseUpdated =_zoomAmountMouse + Input.GetAxis(MouseScrollWheel);

            if (_zoomAmountMouseUpdated < _zoomAmountMouse && Vector3.Distance(owner.Tr.position, owner.Target.position) > zoomDistance.y ||
               _zoomAmountMouseUpdated > _zoomAmountMouse && Vector3.Distance(owner.Tr.position, owner.Target.position) < zoomDistance.x)
                return;
            
            _zoomAmountMouse = _zoomAmountMouseUpdated;
            _zoomAmountMouse = Mathf.Clamp(_zoomAmountMouse, -_maxToClampMouse, _maxToClampMouse);
            var translate = Mathf.Min(Mathf.Abs(Input.GetAxis(MouseScrollWheel)), _maxToClampMouse - Mathf.Abs(_zoomAmountMouse));
            translate *= zoomScale * Mathf.Sign(Input.GetAxis(MouseScrollWheel));
            owner.Tr.Translate(0,0,translate);
            owner.SetDefaultTargetOffset();
        }
    
        public void Set(float zoomScale, Vector2 zoomDistance)
        {
            this.zoomScale = zoomScale;
            this.zoomDistance = zoomDistance;
        }
    }
}
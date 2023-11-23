using UnityEngine;
using UCamSystem.Modules;

namespace UCamSystem.States
{
    public class OrbitState : UCamState<OrbitStateCard>
    {
        public override void Enter()
        {
            base.Enter();
            owner.GetModule<ZoomModule>()?.Active();
            owner.GetModule<OrbitModule>()?.Active();
        }

        public override void Exit()
        {
            base.Exit();
            owner.GetModule<ZoomModule>()?.Deactive();
            owner.GetModule<OrbitModule>()?.Deactive(); 
        }

        public override void SetApplyCard()
        {
            owner.GetModule<ZoomModule>().Set(CurrentCard.zoomScale, CurrentCard.zoomDistance);
            owner.GetModule<OrbitModule>().Set(CurrentCard.rotationSpeedMouse);
        }

        public override void GetData(UCamPoint point)
        {
            base.GetData(point);
            print((OrbitStateCard)point.stateCard);
            SetCard(point.stateCard as OrbitStateCard);
        }
    }
}
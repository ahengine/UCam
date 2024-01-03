using UnityEngine;
using UCamSystem.Modules;
// modules to make the project orbitable . the whole camera dragging controls set up here.
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
            base.SetApplyCard();
            owner.GetModule<ZoomModule>().Set(CurrentCard.Zoom);
            owner.GetModule<OrbitModule>().Set(CurrentCard.Orbit);
        }

        public override void GetData(UCamPoint point)
        {
            base.GetData(point);
            if(point?.stateCard)
                SetCard(point.stateCard as OrbitStateCard);
        }
    }
}
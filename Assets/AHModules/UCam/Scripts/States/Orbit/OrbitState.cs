using UnityEngine;
using UCamSystem.Modules;

namespace UCamSystem.States
{
    public class OrbitState : UCamState<OrbitStateCard>
    {
        public override UCamStates ID => UCamStates.Orbit;
        
        private ZoomModule zoomModule;
        private OrbitModule orbitModule;

        public override void Enter()
        {
            base.Enter();
            zoomModule.Active();
            orbitModule.Active();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
            zoomModule.Update();
            orbitModule.Update();
        }

        public override void Exit()
        {
            base.Exit();
            zoomModule.Deactive();
            orbitModule.Deactive(); 
        }

        public override void ApplyCard()
        {
            base.ApplyCard();
            (zoomModule = owner.GetModule<ZoomModule>()).Set(CurrentCard.Zoom);
            (orbitModule = owner.GetModule<OrbitModule>()).Set(CurrentCard.Orbit);
        }
    }
}
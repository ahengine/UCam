using UCamSystem.Modules;

namespace UCamSystem.States
{
    public class FirstPersonState : UCamState<FirstPersonStateCard>
    {
        public override UCamStates ID => UCamStates.FirstPerson;

        private FirstPersonModule firstPersonModule;

        public override void Enter()
        {
            base.Enter();
            firstPersonModule.Active();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();
            firstPersonModule.Update();
        }

        public override void Exit()
        {
            base.Exit();
            firstPersonModule.Deactive();
            owner.Ghost.SetParent(null);
        }

        public override void ApplyCard() {
            base.ApplyCard();
            (firstPersonModule = owner.GetModule<FirstPersonModule>()).Set(CurrentCard.FirstPerson);
        }
    }
}
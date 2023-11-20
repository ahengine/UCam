using UCamSystem.Modules;

namespace UCamSystem.States
{
    public class FirstPersonState : UCamState<FirstPersonStateCard>
    {
        public override void Enter()
        {
            base.Enter();
            owner.GetModule<FirstPersonModule>()?.Active();
        }

        public override void Exit()
        {
            base.Exit();
            owner.GetModule<FirstPersonModule>()?.Deactive();
        }

        public override void SetApplyCard() =>
            owner.GetModule<FirstPersonModule>().Set(CurrentCard.Ysensitivity);
    }
}
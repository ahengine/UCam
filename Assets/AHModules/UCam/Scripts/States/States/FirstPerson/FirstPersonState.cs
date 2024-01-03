using UCamSystem.Modules;
// modules to make first person camera WORK Correfctly . all the settings about firstperson camera handeling set up here.
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
            owner.Tr.SetParent(null);
        }

        public override void SetApplyCard() {
            base.SetApplyCard();
            owner.GetModule<FirstPersonModule>().Set(CurrentCard.firstPersonModuleCard);
        }
        
        public override void GetData(UCamPoint point)
        {
            base.GetData(point);
            SetCard(point.stateCard as FirstPersonStateCard);
        }
    }
}
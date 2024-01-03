using UnityEngine;
// modules to make whole camera settings work correctly.
namespace UCamSystem.States
{
    public abstract class UCamState<T> : BaseUCamState where T:UCamStateCard
    {
        [SerializeField] private T defaultCard;

        public T CurrentCard { protected set; get; }

        public override void Enter()
        {
            base.Enter();
            if (CurrentCard != null)
                SetDefaultCard();
        }

        public override void Exit()
        {
            base.Exit();
            CurrentCard = null;
        }
        
        public virtual void SetCard(T newCard) { 
            CurrentCard = newCard;
            SetApplyCard();
        }

        public virtual void SetDefaultCard() 
        {
            CurrentCard = defaultCard;
            SetApplyCard();
        }

        public virtual void SetApplyCard() {
            if (!CurrentCard)
                return;

            owner.SetFieldOfView(CurrentCard.FieldOfView);
        }
    }
}
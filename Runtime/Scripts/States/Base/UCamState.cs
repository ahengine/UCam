namespace UCamSystem.States
{
    public abstract class UCamState<T> : BaseUCamState where T:UCamStateCard
    {
        public T CurrentCard { protected set; get; }

        public override void Exit()
        {
            base.Exit();
            CurrentCard = null;
        }
        
        public override void SetCard(UCamStateCard newCard) =>
            SetCard(newCard as T);

        public virtual void SetCard(T newCard) { 
            CurrentCard = newCard;
            ApplyCard();
        }

        public virtual void ApplyCard() {
            if (!CurrentCard)
                return;

            owner.SetFieldOfView(CurrentCard.FieldOfView);
        }
    }
}
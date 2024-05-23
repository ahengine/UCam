namespace UCamSystem.Modules
{
    public class UCamModule
    {
        public UCamModule() {}

        public bool IsActive { private set; get; }

        protected UCam owner { private set; get; }
        public void SetOwner(UCam owner) =>
            this.owner = owner;

        public virtual void Update() {}

        public virtual void Active() =>
            IsActive = true;

        public virtual void Deactive() =>
            IsActive = false;
    }
}
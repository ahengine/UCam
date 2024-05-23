namespace UCamSystem
{
    public abstract class State<T>
    {
        public virtual T ID { get; protected set; }

        public virtual void Enter() {}

        public virtual void Exit() {}

        public virtual void Update() {}

        public virtual void LateUpdate() {}

        public virtual void FixedUpdate() {}
    }
}
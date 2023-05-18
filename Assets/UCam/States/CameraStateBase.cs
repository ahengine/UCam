namespace UCAM
{
    public enum CameraState { None, RTS, Orbit, Static }
    public abstract class CameraStateBase : State<CameraState>
    {
        protected UCam owner;

        public void SetOwner(UCam owner) =>
            this.owner = owner;
        public override void Enter() =>
            base.Enter();

        public override void Exit() =>
            base.Exit();
    }
}

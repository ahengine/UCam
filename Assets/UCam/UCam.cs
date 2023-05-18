using UnityEngine;
using UCAM.Modules;

namespace UCAM
{
    public class UCam : ManualSingleton<UCam>
    {
        public bool IsMobile => Application.isMobilePlatform && !Application.isEditor;

        public Transform Tr { private set; get; }
        public Camera Cam { private set; get; }
        public Transform CamTr => Cam.transform;

        [SerializeField] private CameraStateBase[] states;

        private FiniteStateMachine<CameraState> StateMachine;
        public T GetState<T>(CameraState state) where T : State<CameraState> =>
            (T)StateMachine.GetState(state);

        [field: SerializeField] public UCamModule[] Modules { private set; get; }
        public T GetModule<T>() where T : UCamModule
        {
            for (int i = 0; i < Modules.Length; i++)
                if (Modules[i] is T)
                    return Modules[i] as T;

            return null;
        }

        public void DeactiveAllModules()
        {
            for (int i = 0; i < Modules.Length; i++)
                Modules[i].DoDeactivate();
        }

        protected override void Awake()
        {
            base.Awake();

            Tr = transform;
            Cam = GetComponentInChildren<Camera>();

            for (int i = 0; i < Modules.Length; i++)
                Modules[i].SetOwner(this);

            InitFSM();
        }

        private void InitFSM()
        {
            StateMachine = new FiniteStateMachine<CameraState>();

            for (int i = 0; i < states.Length; i++)
            {
                states[i].SetOwner(this);
                StateMachine.Add(states[i]);
            }

            ChangeState(CameraState.RTS);
        }

        public void ChangeState(CameraState newState) =>
            StateMachine.SetCurrentState(newState);

        private void Update() =>
            StateMachine.Update();

        private void FixedUpdate() =>
            StateMachine.FixedUpdate();
    }
}

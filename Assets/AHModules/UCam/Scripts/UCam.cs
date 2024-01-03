using UnityEngine;
using UCamSystem.Modules;
using UCamSystem.States;
// modules to make whole camera settings work correctly.
public enum UCamStates { None,Orbit, FirstPerson}

namespace UCamSystem
{
    public class UCam : MonoBehaviour
    {
        public static UCam Instance { private set; get; }
        private Camera cam;

        [HideInInspector]
        internal Vector3 TargetOffset;

        [SerializeField] private UCamStates defaultState;
        [SerializeField] private UCamPoint defaultPoint;

        public bool IsLocked { private set; get; }

        public void ChangeLockState(bool value) =>
            IsLocked = value;

        [field: SerializeField] public UCamModule[] Modules { private set; get; }

        public T GetModule<T>() where T : UCamModule
        {
            for (int i = 0; i < Modules.Length; i++)
                if (Modules[i] is T)
                    return Modules[i] as T;

            return null;
        }
        [field: SerializeField] public BaseUCamState[] States { private set; get; }
        public BaseUCamState CurrentState { private set; get; }

        public TState GetState<TState,TStateCard>() where TState : UCamState<TStateCard> where TStateCard:UCamStateCard
        {
            for (int i = 0; i < States.Length; i++)
                if (States[i].GetType() == typeof(TState))
                    return States[i] as TState;

            return null;
        }
        
        public BaseUCamState GetState(UCamStates state)
        {
            for (int i = 0; i < States.Length; i++)
                if (States[i].ID == state)
                    return States[i];

            return null;
        }

        [SerializeField] private float moveSpeed = 4;
        [SerializeField] private float rotateSpeed = 40;

        public Transform Tr { private set; get; }

        private void Awake()
        {
            Instance = this;
            CreateGhost();
            if (Target)
                SetDefaultTargetOffset();
            
            for(int i=0;i<Modules.Length;i++)
                Modules[i].SetOwner(this); 

            for(int i=0;i<States.Length;i++)
                States[i].SetOwner(this);

            SetState(defaultState);

            cam = GetComponent<Camera>();

            if(defaultPoint)
                defaultPoint.Set();
        }

        private void CreateGhost() {
            Tr = new GameObject("UCam Target").transform;
            Tr.position = transform.position;
            Tr.rotation = transform.rotation;
        }

        private void LateUpdate() 
        {
            if(IsLocked)
                return;

            AllowActionProcess();

            for(int i=0;i<Modules.Length;i++)
               if(Modules[i].IsActive)
                  Modules[i].Updates();

            CurrentState?.LateUpdates();
            UpdateTransform();
        }

        [field:SerializeField] public Transform Target { private set; get; }
        public void SetTarget(Transform target) 
        {
            Target = target;
            SetDefaultTargetOffset();
        }
        public void SetDefaultTargetOffset() =>
            TargetOffset = Tr.position - Target.position;

        private void UpdateTransform() =>
            transform.SetPositionAndRotation(
                Vector3.Lerp(transform.position, Tr.position, moveSpeed * Time.deltaTime),
                Quaternion.Slerp(transform.rotation, Tr.rotation, rotateSpeed * Time.deltaTime)
            );

        public void SetState(UCamStates newState, bool force = false) {
            //if(CurrentState?.ID == newState && !force) return;

            CurrentState?.Exit();
            CurrentState = GetState(newState);
            CurrentState?.Enter();
        }

        public void SetGhostPositionRotation(Transform point) =>
            Tr.SetPositionAndRotation(point.position, point.rotation);

        #region  AllowAction
        [field:SerializeField] public bool CantAction { private set; get; }

        private void AllowActionProcess() {
            if (Input.GetMouseButtonDown(0))
                CantAction = Input.mousePosition.x > Screen.width / 100 * ScreenTouchSpacePercent;

            if (Input.GetMouseButtonUp(0))
                CantAction = false;
        }

        [SerializeField, Range(0, 100)] private float ScreenTouchSpacePercent = 80;
        #endregion

        public void SetClippingNearPlan(float value) =>
            cam.nearClipPlane = value;

        public void SetFieldOfView(float value) =>
            cam.fieldOfView = value;

        public void SetParent(Transform parent) {
            Tr.SetParent(parent);
            if (!parent)
                return;
                
            Tr.localPosition = Vector3.zero;
            Tr.localRotation = Quaternion.identity;
        }
    }
}
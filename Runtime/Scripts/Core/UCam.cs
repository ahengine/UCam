using UnityEngine;
using UCamSystem.Modules;
using UCamSystem.States;
using System.Collections.Generic;

public enum UCamStates { None,Orbit, FirstPerson}

namespace UCamSystem
{
    public class UCam : MonoBehaviour
    {
        public static UCam Instance { private set; get; }
        private Camera cam;

        [HideInInspector]
        internal Vector3 TargetOffset;

        #region  Locker
        private List<MonoBehaviour> lockers = new List<MonoBehaviour>();
        public void AddLocker(MonoBehaviour locker) =>
            lockers.Add(locker);

        public void RemoveLocker(MonoBehaviour locker) =>
            lockers.Remove(locker);

        public bool IsLocked => lockers.Count > 0;
        #endregion

        protected List<UCamModule> modules = new List<UCamModule>();
        public T GetModule<T>() where T : UCamModule,new()
        {
            for (int i = 0; i < modules.Count; i++)
                if (modules[i] is T)
                    return modules[i] as T;

            T AddModule()
            {
                var module = new T();
                module.SetOwner(this);
                modules.Add(module);

                return module;
            }

            return AddModule();
        }

        [field: SerializeField] public List<BaseUCamState> states { private set; get; } = new List<BaseUCamState>();
        public BaseUCamState CurrentState { private set; get; }

        public TState GetState<TState,TStateCard>() where TState : UCamState<TStateCard>, new() where TStateCard:UCamStateCard
        {
            for (int i = 0; i < states.Count; i++)
                if (states[i].GetType() == typeof(TState))
                    return states[i] as TState;
 
            TState AddState() {
                var state = new TState();
                state.SetOwner(this);
                states.Add(state);
                return state;
            }

            return AddState();
        }
        
        public BaseUCamState GetState(UCamStates state)
        {
            for (int i = 0; i < states.Count; i++)
                if (states[i].ID == state)
                    return states[i];

            return null;
        }

        public BaseUCamState GetState(UCamStateCard card)
        {
            for (int i = 0; i < states.Count; i++)
                if (states[i].ID == card.StateId)
                    return states[i];

            return card.GetState(this);
        }

        [SerializeField] private float moveSpeed = 4;
        [SerializeField] private float rotateSpeed = 40;

        public GhostTransform Ghost { private set; get; }

        private void Awake()
        {
            Instance = this;
            Ghost = GhostTransform.CreateInstance();
            Ghost.SetPositionRotation(transform);

            if (Target)
                SetDefaultTargetOffset();

            cam = GetComponent<Camera>();
        }

        private void LateUpdate() 
        {
            if(IsLocked)
                return;

            CurrentState?.LateUpdate();

            UpdateTransform();
        }

        public Transform Target { private set; get; }
        public void SetTarget(Transform target) 
        {
            Target = target;
            SetDefaultTargetOffset();
        }
        public void SetDefaultTargetOffset() =>
            TargetOffset = Ghost.transform.position - Target.position;

        private void UpdateTransform() =>
            transform.SetPositionAndRotation(
                Vector3.Lerp(transform.position, Ghost.transform.position, moveSpeed * Time.deltaTime),
                Quaternion.Slerp(transform.rotation, Ghost.transform.rotation, rotateSpeed * Time.deltaTime)
            );

        public void SetState(UCamStates newState, bool force = false) {
            if(CurrentState != null && CurrentState.ID == newState && !force) return;

            CurrentState?.Exit();
            CurrentState = GetState(newState);
            CurrentState?.Enter();
        }

        public void SetState(UCamStateCard card, bool force = false) {

            if(!card)
                return;

            if(CurrentState?.ID != card.StateId && !force)
            {
                CurrentState.SetCard(card);
                return;
            }

            CurrentState?.Exit();
            CurrentState = card.GetState(this);
            if(CurrentState != null)
            {
                CurrentState.SetCard(card);
                CurrentState.Enter();
            }
        }

        public void SetClippingNearPlan(float value) =>
            cam.nearClipPlane = value;
        public void SetFieldOfView(float value) =>
            cam.fieldOfView = value;
    }
}
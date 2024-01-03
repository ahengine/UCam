using UnityEngine;
using UCamSystem.States;
// modules to control the camera and view of the project
namespace UCamSystem
{
    public class UCamPoint : MonoBehaviour
    {
        [SerializeField] private bool onEnable;
        [SerializeField] private UCamStates state;
        [field:SerializeField] public UCamStateCard stateCard { private set; get; }
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private Transform parentPoint;

        protected virtual void Awake()
        {
           // if (!startPoint)
           //     startPoint = transform;  
        }

        private void OnEnable() {
            if (onEnable)
                Set();  
        }

        public void Set() {

            if (!UCam.Instance)
                return;
            if(targetPoint)
                UCam.Instance.SetTarget(targetPoint);
            if(startPoint)
                UCam.Instance.SetGhostPositionRotation(startPoint);
            UCam.Instance.SetParent(parentPoint);
            UCam.Instance.SetState(state, true);
            if (stateCard)
                UCam.Instance.CurrentState.GetData(this);
        }
#if UNITY_EDITOR
        [SerializeField] private bool allowTest;
        private void Update() {
            if(!allowTest)
                return;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Set();
                print(UCam.Instance.CurrentState.name);
            }
        }
#endif
    }
}
using UnityEngine;
using UCamSystem.States;

namespace UCamSystem
{
    public class UCamPoint : MonoBehaviour
    {
        [SerializeField] private UCamStates state;
        [field:SerializeField] public UCamStateCard stateCard { private set; get; }
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform targetPoint;

        public void Set() {

            if (!UCam.Instance)
                return;

            if(targetPoint)
                UCam.Instance.SetTarget(targetPoint);
            if(startPoint)
                UCam.Instance.SetGhostPositionRotation(startPoint);
            UCam.Instance.SetState(state, true);
            if (stateCard)
                UCam.Instance.CurrentState.GetData(this);
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Set();
                print(UCam.Instance.CurrentState.name);
            }
        }
    }
}
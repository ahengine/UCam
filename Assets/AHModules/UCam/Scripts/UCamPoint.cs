using UnityEngine;
using UCamSystem.States;

namespace UCamSystem
{
    public class UCamPoint : MonoBehaviour
    {
        [SerializeField] private UCamStates state;
        [SerializeField] private UCamStateCard stateCard;
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform targetPoint;

        public void Set() {

            if (!UCam.Instance)
                return;

            if(stateCard)
                UCam.Instance.GetState<UCamState<UCamStateCard>, UCamStateCard>(state)?.SetCard(stateCard);
            UCam.Instance.SetState(state, true);
            if(targetPoint)
                UCam.Instance.SetTarget(targetPoint);
            if(startPoint)
                UCam.Instance.SetGhostPositionRotation(startPoint);
        }
    }
}
using UnityEngine;
using UCamSystem.States;

namespace UCamSystem
{
    public class UCamPoint : MonoBehaviour
    {
        [SerializeField] private bool onEnable;
        [field:SerializeField] public UCamStateCard stateCard { private set; get; }
        [SerializeField] private bool isStartPoint = true;
        [SerializeField] private bool parent = true;
        [SerializeField] private Transform target;

        private UCam owner;

        public void SetOwner(UCam owner) 
            => this.owner = owner;
        private bool HaveOwner() {
            
               if(!owner)
                SetOwner(UCam.Instance);

            return owner;
        }

        private void OnEnable() {
            if (onEnable)
                Set();  
        }

        public void Set() {
            
            if(!HaveOwner())
                return;

            if(target)
                owner.SetTarget(target);
            if(isStartPoint)
                owner.Ghost.SetPositionRotation(transform);

            owner.Ghost.SetParent(transform);

            if(!stateCard)
                return;

            owner.SetState(stateCard, true);
        }

#if UNITY_EDITOR
        [Header("Editor Test"),SerializeField] private KeyCode keyCode;
        private void Update() 
        {
            if(!HaveOwner())
                return;

            if(Input.GetKeyDown(keyCode))
            {
                Set();
                if(owner.CurrentState != null)
                print(owner.CurrentState.ID);
            }
        }

        [SerializeField] private bool distanceToTargetCheck;
        [SerializeField] private Vector2 distanceToTargetAreaRange = new Vector2(20,100);
        private void OnDrawGizmos() {
            
            if(distanceToTargetCheck && target)
            {
                float distance = Vector3.Distance(transform.position,target.position);
                bool distanceInArea = distance >= distanceToTargetAreaRange.x && distance <= distanceToTargetAreaRange.y;           
                Debug.DrawRay(transform.position, target.position - transform.position,distanceInArea ? Color.green :Color.red);
            }
        }
#endif
    }
}
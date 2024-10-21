using UnityEngine;
using UCamSystem.States;
using UnityEngine.Events;

namespace UCamSystem
{
    public class UCamPoint : MonoBehaviour
    {
        private static UCamPoint current;

        private bool HaveOwner =>
            owner || SetOwner(UCam.Instance);

        [SerializeField] private bool onEnable;
        [SerializeField] private UCamStateCard stateCard;
        [SerializeField] private Transform parent;
        [SerializeField] private Transform target;

        [field:SerializeField] public UnityEvent OnSet {private set; get;}
        [field:SerializeField] public UnityEvent OnLeave {private set; get;}

        private UCam owner;

        public UCam SetOwner(UCam owner) => 
            this.owner = owner;

        private void OnEnable() {
            if (onEnable)
                Set();  
        }

        [ContextMenu("Set")]
        public void Set() 
        {    
            if(!HaveOwner)
                return;

            if(target)
                owner.SetTarget(target);

            owner.Ghost.SetPositionRotation(transform);
            owner.Ghost.SetParent(parent ?? transform);
            Events();
            if(!stateCard)
                return;

            owner.SetState(stateCard, true);
        }

        private void Events()
        {
            if(current)
                current.OnLeave?.Invoke();

            current = this;

            OnSet?.Invoke();
        }

#if UNITY_EDITOR
        [Header("Editor Test"),SerializeField] private KeyCode keyCode;
        private void Update() 
        {
            if(!HaveOwner)
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
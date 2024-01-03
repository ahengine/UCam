using UnityEngine;

namespace UCamSystem.Modules
{
    public class UCamModule : MonoBehaviour
    {
        public bool IsActive { private set; get; }

        protected UCam owner { private set; get; }
        public void SetOwner(UCam owner) =>
            this.owner = owner;

        public virtual void Updates()
        {
            
        }

        public virtual void Active() =>
            IsActive = true;

        public virtual void Deactive() =>
            IsActive = false;
    }
}
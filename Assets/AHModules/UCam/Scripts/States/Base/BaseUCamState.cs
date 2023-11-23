using UnityEngine;
using UPatterns;

namespace UCamSystem.States
{
    public abstract class BaseUCamState : State<UCamStates>
    {
        protected UCam owner;

        public virtual void SetOwner(UCam owner) =>
            this.owner = owner;

        public virtual void GetData(UCamPoint point) {
            
        }
    }
}
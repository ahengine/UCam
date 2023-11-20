using UnityEngine;
using UPatterns;

namespace UCamSystem.States
{
    public abstract class BaseUCamState : State<CameraStates>
    {
        protected UCam owner;

        public virtual void SetOwner(UCam owner) =>
            this.owner = owner;
    }
}
using System;
using UnityEngine;

namespace UCamSystem.States
{
    public class UCamStateCard : ScriptableObject
    {
        public virtual UCamStates StateId => UCamStates.None;
        public BaseUCamState StateSingleton => GetState(UCam.Instance);
        public virtual BaseUCamState GetState(UCam cam) => null;

        [field:SerializeField] public float FieldOfView { private set; get; } = 60;
    }
}
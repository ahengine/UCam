using System;
using UCamSystem.Modules;
using UnityEngine;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam Cards/FirstPerson State", fileName = "FirstPersonState", order = 0)]
    public class FirstPersonStateCard : UCamStateCard
    {
        public override UCamStates StateId => UCamStates.FirstPerson;
        public override BaseUCamState GetState(UCam cam) =>
            cam.GetState<FirstPersonState, FirstPersonStateCard>();

        [field:SerializeField] public FirstPersonModuleData FirstPerson { private set; get; }
    }
}
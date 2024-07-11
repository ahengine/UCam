using UnityEngine;
using UCamSystem.Modules;
using System;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam Cards/Orbit State", fileName = "OrbitState", order = 0)]
    public class OrbitStateCard : UCamStateCard
    {
        public override UCamStates StateId => UCamStates.Orbit;
        public override BaseUCamState GetState(UCam cam) =>
            cam.GetState<OrbitState, OrbitStateCard>();

        [field:SerializeField] public ZoomModuleData Zoom { private set; get; }
        [field:SerializeField] public OrbitModuleData Orbit { private set; get; }

    }
}
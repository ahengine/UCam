using UnityEngine;
using UCamSystem.Modules;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam Cards/States/Orbit", fileName = "OrbitState", order = 0)]
    public class OrbitStateCard : UCamStateCard
    {
        [field:SerializeField] public ZoomModuleCard Zoom { private set; get; }
        [field:SerializeField] public OrbitModuleCard Orbit { private set; get; }

    }
}
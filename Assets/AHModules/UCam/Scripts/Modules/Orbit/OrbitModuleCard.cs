using UnityEngine;
using UCamSystem.Models;

namespace UCamSystem.Modules
{
    [CreateAssetMenu(menuName = "UCam Cards/Modules/Orbit", fileName = "Orbit", order = 0)]
    public class OrbitModuleCard : UCamModuleCard
    {
        [field:SerializeField] public RotationDirection RotationDirection { private set; get; }
        [field:SerializeField] public float MouseSpeed { private set; get; } = 5;
    }
}
using UnityEngine;
using UCamSystem.Models;

namespace UCamSystem.Modules
{
    [CreateAssetMenu(menuName = "UCam Cards/Modules/First Person", fileName = "First Person", order = 0)]
    public class FirstPersonModuleCard : UCamModuleCard
    {
        [field: SerializeField] public Space Space { private set; get; } = Space.World;
        [field:SerializeField] public float Sensitivity { private set; get; } = 5;
        [field:SerializeField] public RotationLimit RotationLimit { private set; get; }
        [field:SerializeField] public RotationDirection RotationDirection { private set; get; }
    }
}
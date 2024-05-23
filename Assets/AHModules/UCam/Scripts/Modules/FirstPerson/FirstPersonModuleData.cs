using UnityEngine;
using UCamSystem.Models;

namespace UCamSystem.Modules
{
    [System.Serializable]
    public class FirstPersonModuleData : UCamModuleData
    {
        [field: SerializeField] public Space Space { private set; get; } = Space.World;
        [field:SerializeField] public float Sensitivity { private set; get; } = 5;
        [field:SerializeField] public RotationDirection RotationX { private set; get; }
        [field:SerializeField] public RotationDirection RotationY { private set; get; }
        [field:SerializeField] public RotationLimit RotationLimitZ { private set; get; }
    }
}
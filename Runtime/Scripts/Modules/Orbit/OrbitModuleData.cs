using UnityEngine;

namespace UCamSystem.Modules
{
    [System.Serializable]
    public class OrbitModuleData : UCamModuleData
    {
        [field:SerializeField] public bool RotationX { private set; get; }
        [field:SerializeField] public Vector2 RotationXLimit { private set; get; } = new Vector2(-45,45);
        [field:SerializeField] public bool RotationY { private set; get; }
        [field:SerializeField] public float MouseSpeed { private set; get; } = 5;
    }
}
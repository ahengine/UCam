using UnityEngine;

namespace UCamSystem.Modules
{
    [System.Serializable]
    public class ZoomOrthoModuleData : UCamModuleData
    {
        [field:SerializeField] public float Scale { private set; get; } = 10;
        [field:SerializeField] public Vector2 RangeDistance { private set; get; } = new Vector2(10, 20);
    }
}
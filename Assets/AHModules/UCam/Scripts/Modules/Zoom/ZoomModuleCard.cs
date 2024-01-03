using UnityEngine;

namespace UCamSystem.Modules
{
    [CreateAssetMenu(menuName = "UCam Cards/Modules/Zoom", fileName = "Zoom", order = 0)]
    public class ZoomModuleCard : UCamModuleCard
    {
        [field:SerializeField] public float Scale { private set; get; } = 10;
        [field:SerializeField] public Vector2 RangeDistance { private set; get; } = new Vector2(10, 20);
    }
}
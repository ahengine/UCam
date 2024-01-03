using UnityEngine;

namespace UCamSystem.States
{
    public class UCamStateCard : ScriptableObject
    {
        [field:SerializeField] public float FieldOfView { private set; get; } = 60;
    }
}
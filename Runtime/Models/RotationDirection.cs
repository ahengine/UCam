using Serializable = System.SerializableAttribute;
using UnityEngine;

namespace UCamSystem.Models
{
    [Serializable]
    public class RotationDirection
    {
        [field:SerializeField] public bool Enable { private set; get;}
        [field:SerializeField] public RotationLimit Limit { private set; get;}
    }

    [Serializable]
    public class RotationLimit
    {
        [field:SerializeField] public bool Enable { private set; get;}
        [field:SerializeField] public Vector2 Range { private set; get;} = new Vector2(-60f, 60f);

        public float Clamp(float value) =>
            Mathf.Clamp(value,Range.x,Range.y);
    }
}
using Serializable = System.SerializableAttribute;
using UnityEngine;

namespace UCamSystem.Models
{
    [Serializable]
    public class RotationLimit
    {
        public bool limitX;
        public Vector2 limitXRange = new Vector2(-60f, 60f);

        public bool limitY;
        public Vector2 limitYRange = new Vector2(-60f, 60f);

        public bool limitZ;
        public Vector2 limitZRange = new Vector2(-60f, 60f);
    }

    [Serializable]
    public class RotationDirection
    {
        public bool X;
        public bool Y;
        public bool Z;
    }
}
using UnityEngine;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam States Cards/OrbitState", fileName = "OrbitState", order = 0)]
    public class OrbitStateCard : UCamStateCard
    {
        public float rotationSpeedMouse = 5;
        public float zoomScale = 10;
        public Vector2 zoomDistance = new Vector2(10, 20);
    }
}
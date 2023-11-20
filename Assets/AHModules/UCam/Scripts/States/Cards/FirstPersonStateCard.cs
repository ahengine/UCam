using UnityEngine;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam States Cards/FirstPersonCard", fileName = "FirstPerson", order = 0)]
    public class FirstPersonStateCard : UCamStateCard
    {
        public float Ysensitivity = 5;
    }
}
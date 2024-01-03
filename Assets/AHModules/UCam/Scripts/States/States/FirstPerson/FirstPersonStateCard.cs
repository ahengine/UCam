using UCamSystem.Modules;
using UnityEngine;

namespace UCamSystem.States
{
    [CreateAssetMenu(menuName = "UCam Cards/States/FirstPerson", fileName = "FirstPersonState", order = 0)]
    public class FirstPersonStateCard : UCamStateCard
    {
        [field:SerializeField] public FirstPersonModuleCard firstPersonModuleCard { private set; get; }
    }
}
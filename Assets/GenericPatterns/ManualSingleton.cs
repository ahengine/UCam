using UnityEngine;

public class ManualSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Singleton { protected set; get; }
    public static void SetSingle(T instance) =>
        Singleton = instance;

    [SerializeField] private bool isSingleton;

    protected virtual void Awake()
    {
        if (isSingleton)
            SetSingle(this as T);
    }

    protected virtual void OnDestroy()
    {
        if(Singleton == this)
            Singleton = null;
    }
}

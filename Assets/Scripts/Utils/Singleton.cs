using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T _instance;
    
    public static T Instance => _instance;

    public static bool IsInitialized => _instance != null;

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("More than one Singleton Instance of " + _instance.name);
            
            Destroy(gameObject);
        }

        else
        {
            _instance = (T) this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
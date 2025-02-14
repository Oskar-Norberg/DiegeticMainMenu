using UnityEngine;

namespace DiegeticMainMenu.Singleton
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.LogError("Instance of " + typeof(T).Name + " is null");
                }

                return _instance;
            }
        }

        private static T _instance;

        protected virtual void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }
        
            _instance = this as T;
        }

        protected void OnApplicationQuit()
        {
            _instance = null;
            Destroy(gameObject);
        }
    }
}
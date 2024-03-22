using UnityEngine;

namespace ReusedCode
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => _instance;

        public virtual bool ShouldDestroyOnLoad => true;

        private static T _instance = null;

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            
            if (!ShouldDestroyOnLoad)
            {
                if (transform.parent != null)
                {
                    transform.SetParent(null);
                }
                DontDestroyOnLoad(gameObject);
            }
        }

        public static void DestroyInstance()
        {
            if (_instance == null)
            {
                return;
            }

            Destroy(_instance.gameObject);
        }
    }
}


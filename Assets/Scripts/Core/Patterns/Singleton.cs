using UnityEngine;
using System.Collections;
using System;

namespace MVP
{
    /// <summary>
    /// Prefab attribute. Use this on child classes
    /// to define if they have a prefab associated or not
    /// By default will attempt to load a prefab
    /// that has the same name as the class,
    /// otherwise [Resource("path/to/prefab")] to define it specifically. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class ResourceAttribute : Attribute
    {
        string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public ResourceAttribute()
        {
            this._name = "";
        }

        public ResourceAttribute(string name)
        {
            this._name = name;
        }
    }

    /// <summary>
    /// MONOBEHAVIOR PSEUDO SINGLETON ABSTRACT CLASS
    /// usage        : can be attached to a gameobject and if not
    ///              : this will create one on first access
    /// example      : public sealed class MyClass : Singleton<MyClass> {
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance = null;
        private static object _lock = new object();
        private static bool applicationIsQuitting = false;
        public static bool IsAwake
        {
            get
            {
                return (_instance != null);
            }
        }

        /// <summary>
        /// gets the instance of this Singleton
        /// use this for all instance calls:
        /// MyClass.Instance.MyMethod();
        /// or make your public methods static
        /// and have them use Instance internally
        /// for a nice clean interface
        /// </summary>
        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed" +
                    " Recreate again.");
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        string singletonObjName = typeof(T).Name.ToString();
                        GameObject singletonObj = GameObject.Find(singletonObjName);

                        if (singletonObj == null) //if still not found try prefab or create
                        {
                            // checks if the [Prefab] attribute is set and pulls that if it can
                            bool hasPrefab = Attribute.IsDefined(typeof(T), typeof(ResourceAttribute));
                            if (hasPrefab)
                            {
                                ResourceAttribute attr = (ResourceAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(ResourceAttribute));
                                string prefabName = attr.Name;
                                try
                                {
                                    singletonObj = (GameObject)GameObject.Instantiate(Resources.Load(string.IsNullOrEmpty(prefabName) ? singletonObjName : prefabName));
                                }
                                catch (Exception e)
                                {
                                    Debug.LogError("could not instantiate prefab even though prefab attribute was set: " + e.Message + "\n" + e.StackTrace);
                                }
                            }

                            if (singletonObj == null)
                            {
                                singletonObj = new GameObject();
                            }

                            DontDestroyOnLoad(singletonObj);
                            singletonObj.name = singletonObjName;
                        }

                        _instance = singletonObj.GetComponent<T>();
                        if (_instance == null)
                        {
                            _instance = singletonObj.AddComponent<T>();
                        }

                        _instance.Init();
                    }

                    return _instance;
                }
            }
        }

        // in your child class you can implement Awake()
        // and add any initialization code you want.


        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        /// it will create a buggy ghost object that will stay on the Editor scene
        /// even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        protected virtual void OnApplicationQuit()
        {
            applicationIsQuitting = true;
        }

        // Helper function to initialize the Singleton object.
        public void Load(GameObject parentObj = null)
        {
            SetParent(parentObj);
        }

        protected virtual void Init() { }


        /// <summary>
        /// Implement details in child class if it needs to be reset at some point.
        /// </summary>
        protected virtual void Reset() { }


        /// <summary>
        /// Parent this to another gameobject by string
        /// call from Awake if you so desire
        /// </summary>
        protected void SetParent(GameObject parentGO)
        {
            if (parentGO != null)
            {
                this.transform.parent = parentGO.transform;
            }
        }
    }
}
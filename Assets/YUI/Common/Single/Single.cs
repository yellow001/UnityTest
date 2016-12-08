using UnityEngine;
using System.Collections;

namespace YUI
{
    public abstract class Single<T> where T : class,new()
    {

        protected static T _Instance = null;

        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new T();
                }
                return _Instance;
            }
        }

        protected Single()
        {
            if (_Instance == null)
                Init();
            else
                throw new SingleExpection(typeof(T).ToString()+" instance is not null, can not new again");
        }

        public virtual void Init()
        {
            Debug.Log("single init");
        }

    }
}

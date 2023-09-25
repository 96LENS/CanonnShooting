//#define SINGLETON_DEBUG
using UnityEngine;

namespace DynamisFramework
{
    namespace Utility
    {
        /// <summary>
        /// Hierarchyに存在するオブジェクト用シングルトン
        /// ※ MonoBehaviourにするオブジェクトに継承してください。
        /// </summary>
        public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
        {
            //=====================================================================================================================
            // 変数
            //=====================================================================================================================
            private static T _instance = null;
            private static bool _isInstantiated = false;

            //=====================================================================================================================
            // プロパティ
            //=====================================================================================================================
            public static T Instance { get { return _instance; } }
            public static bool IsInstantiated { get { return _isInstantiated; } }

            //=====================================================================================================================
            // MonoBehaviour関数
            //=====================================================================================================================

            /// <summary>
            /// インスタンス生成
            /// </summary>
            protected virtual void Awake()
            {
                _instance = GetComponent<T>();

                if (_instance == null)
                {
                    Debug.LogError($"{this.name} instance can not be found.");
                    return;
                }

                _isInstantiated = true;

#if SINGLETON_DEBUG
                Debug.Log($"<color=green>[{this.gameObject.name}]</color> instance created.");
#endif
            }

            /// <summary>
            /// インスタンス解放
            /// </summary>
            protected virtual void OnDestroy()
            {
                _instance = null;
                _isInstantiated = false;

#if SINGLETON_DEBUG
                Debug.Log($"<color=green>[{this.gameObject.name}]</color> instance released.");
#endif
            }

        } // class SingletonMonoBehaviour
    }// namespace Utility
}// namespace DynamisFramework

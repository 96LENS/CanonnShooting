#define PROCESS_MANAGER_DEBUG
using System.Collections.Generic;
using UnityEngine;

using CannonShooting.Utility;

namespace CannonShooting
{
    namespace Process
    {
        /// <summary>
        /// MonoBehaviourのルーチンを管理するクラス
        /// </summary>
        public class GameProcessManager : SingletonMonoBehaviour<GameProcessManager>
        {
            //=====================================================================================================================
            // 内部クラス・列挙型定義
            //=====================================================================================================================

            //=====================================================================================================================
            // 定数
            //=====================================================================================================================

            //=====================================================================================================================
            // 変数
            //=====================================================================================================================
            private List<IGameProcess> _processList;

            //=====================================================================================================================
            // プロパティ
            //=====================================================================================================================

            //=====================================================================================================================
            // コンストラクタ
            //=====================================================================================================================

            //=====================================================================================================================
            // MonoBehaviour関数
            //=====================================================================================================================

            protected override void Awake()
            {
                base.Awake();
                _Initialize();
            }

            private void FixedUpdate()
            {
                if (_processList.IsNullOrEmpty() == true)
                {
                    return;
                }

                foreach (var process in _processList)
                {
                    process.FixedUpdate();
                }
            }


            private void Update()
            {
                if (_processList.IsNullOrEmpty() == true)
                {
                    return;
                }

                foreach (var process in _processList)
                {
                    process.Update();
                }
            }

            private void LateUpdate()
            {
                if (_processList.IsNullOrEmpty() == true)
                {
                    return;
                }

                foreach (var process in _processList)
                {
                    process.FixedUpdate();
                }
            }

            protected override void OnDestroy()
            {
                if (_processList.IsNullOrEmpty() == true)
                {
                    return;
                }

                foreach (var process in _processList)
                {
                    process.Destroy();
                }

                _processList.Clear();
                _processList = null;
                base.OnDestroy();
            }

            //=====================================================================================================================
            // Private関数
            //=====================================================================================================================
            private void _Initialize()
            {
                _processList = new List<IGameProcess>();
            }

            //=====================================================================================================================
            // Public関数
            //=====================================================================================================================
            
            /// <summary>
            /// Processの登録
            /// </summary>
            /// <param name="process">追加するプロセス</param>
            public void AddProcess(IGameProcess process)
            {
                _processList.Add(process);

#if PROCESS_MANAGER_DEBUG
                Debug.Log($"<color=green>[GameProcessManager]</color> {process.GetType().Name} added.");
#endif
            }

            /// <summary>
            /// Processの解放
            /// </summary>
            /// <param name="process"></param>
            public void RemoveProcess(IGameProcess process)
            {
                if (!_processList.Contains(process))
                {
                    return;
                }

                _processList.Remove(process);

#if PROCESS_MANAGER_DEBUG
                Debug.Log($"<color=green>[GameProcessManager]</color> {process.GetType().Name} removed.");
#endif
            }
        } // MonoBehaviourprocessManager
    }//namespace Process
}//namespace CannonShooting
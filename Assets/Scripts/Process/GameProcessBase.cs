using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CannonShooting
{
    namespace Process
    {
        /// <summary>
        /// GameProcessの基礎クラス
        /// このクラスを継承したクラスのインスタンス生成時にGameProcessManagerに登録されます
        /// </summary>
        public class GameProcessBase<Process> : IGameProcess where Process : GameProcessBase<Process>
        {
            //=====================================================================================================================
            // 変数
            //=====================================================================================================================
            private Process _process;

            //=====================================================================================================================
            // コンストラクタ
            //=====================================================================================================================
            public GameProcessBase(Process process)
            {
                if(!GameProcessManager.IsInitialized)
                {
                    Debug.LogError($"[{_process}] Initialization failed. GameProcessManager was not initialized.");
                    return;
                }

                _process = process;
                _process.Initialize();

                GameProcessManager.Instance.AddProcess(process);
            }

            //=====================================================================================================================
            // Public関数
            //=====================================================================================================================
            public virtual void Initialize()
            {

            }

            public virtual void FixedUpdate()
            {

            }

            public virtual void Update()
            {

            }

            public virtual void LateUpdate()
            {

            }

            public virtual void Destroy()
            {
                if (!GameProcessManager.IsInitialized)
                {
                    Debug.LogError($"[{_process}] Initialization failed. GameProcessManager was not initialized.");
                    return;
                }

                if(_process == null)
                {
                    return;
                }

                GameProcessManager.Instance.RemoveProcess(_process);
                _process = null;
            }
        } //class GameProcessBase
    }//namespace Process
}//namespace CannonShooting

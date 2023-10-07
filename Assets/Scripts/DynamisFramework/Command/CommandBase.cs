using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamisFramework
{
    namespace Command
    {
        /// <summary>
        /// コマンド基礎クラス
        /// </summary>
        public abstract class CommandBase : ICommand
        {

            //=====================================================================================================================
            // コンストラクタ
            //=====================================================================================================================
            public CommandBase()
            {
                if(CommandManager.IsInstantiated == false)
                {
                    string name = this.GetType().Name;
                    Debug.LogError($"[{name}] => failed constract. CommandManager was not instantiated.");
                    return;
                }

                // コマンドを管理クラスに登録
                CommandManager.Instance.EnqueueCommand(this);
            }

            //=====================================================================================================================
            // Public関数
            //=====================================================================================================================
            
            /// <summary>
            /// コマンド実行関数
            /// </summary>
            public abstract void Execute();

        } // classs CommandBase
    }// namespace Command
}// namespace DynamisFramework

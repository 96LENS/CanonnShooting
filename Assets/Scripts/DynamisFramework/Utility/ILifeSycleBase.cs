using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamisFramework.Utility
{
    /// <summary>
    ///  Unityのライフサイクル関数に則ったライフサイクル関数を定義
    /// </summary>
    public interface ILifeSycleBase
    {
        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================

        //=====================================================================================================================
        // 関数
        //=====================================================================================================================
        IEnumerator Initialize();
        void FixedUpdate();
        void Update();
        void LateUpdate();
        IEnumerator Termination();

    } // class IBaseSystem
}// namespace DynamisFramework.Utility

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CannonShooting
{
    /// <summary>
    /// 弾のGameObjectのアクセス定義
    /// </summary>
    public class BulletContainer : DynamisFramework.Container.ContainerBase<BulletContainer>
    {
        //=====================================================================================================================
        // SerializeField変数
        //=====================================================================================================================

        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================
        public Action<Collision> OnCollisionEnterCallback { get; set; }
        public Action<Collision> OnCollisionStayCallback { get; set; }
        public Action<Collision> OnCollisionExitCallback { get; set; }

        //=====================================================================================================================
        // MonoBehaviour関数
        //=====================================================================================================================
        /// <summary>
        /// 衝突始め判定
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            OnCollisionEnterCallback?.Invoke(collision);
        }

        /// <summary>
        /// 衝突中判定
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionStay(Collision collision)
        {
            OnCollisionStayCallback?.Invoke(collision);
        }

        /// <summary>
        /// 衝突終了判定
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionExit(Collision collision)
        {
            OnCollisionExitCallback?.Invoke(collision);
        }

        //=====================================================================================================================
        // Private関数
        //=====================================================================================================================

        //=====================================================================================================================
        // Public関数
        //=====================================================================================================================

    } // class BulletContainer
}// namespace CannonShooting

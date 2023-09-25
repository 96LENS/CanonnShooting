using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CannonShooting
{
    public class CannonManager : DynamisFramework.Utility.Singleton<CannonManager>
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
        private List<CannonBase> _cannonList = null;

        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================

        //=====================================================================================================================
        // コンストラクタ
        //=====================================================================================================================
        public CannonManager()
        {
            _cannonList = new List<CannonBase>();
        }

        //=====================================================================================================================
        // ライフサイクル関数
        //=====================================================================================================================
        public void FixedUpdate()
        {
            if (_cannonList.IsNullOrEmpty())
            {
                return;
            }

            foreach(CannonBase cannon in _cannonList)
            {
                cannon.FixedUpdate();
            }
        }

        public void Update()
        {
            if (_cannonList.IsNullOrEmpty())
            {
                return;
            }

            foreach (CannonBase cannon in _cannonList)
            {
                cannon.Update();
            }
        }

        public void LateUpdate()
        {
            if (_cannonList.IsNullOrEmpty())
            {
                return;
            }

            foreach (CannonBase cannon in _cannonList)
            {
                cannon.LateUpdate();
            }
        }


        //=====================================================================================================================
        // Private関数
        //=====================================================================================================================

        //=====================================================================================================================
        // Public関数
        //=====================================================================================================================

        /// <summary>
        ///  キャノンを追加
        /// </summary>
        /// <returns></returns>
        public bool AddCannon(CannonBase cannon)
        {
            if (_cannonList.Contains(cannon))
            {
                return false;
            }

            _cannonList.Add(cannon);
            return true;
        }

        /// <summary>
        /// キャノンを削除
        /// </summary>
        /// <param name="cannon">キャノンのインスタンス</param>
        /// <returns></returns>
        public bool RemoveCannon(CannonBase cannon)
        {
            return _cannonList.Remove(cannon);
        }

        /// <summary>
        /// キャノンを削除
        /// </summary>
        /// <param name="id">キャノンのID</param>
        /// <returns></returns>
        public bool RemoveCannon(string id)
        {
            CannonBase cannon = _cannonList.Find(cannon => cannon.ID == id);
            if(cannon == null)
            {
                return false;
            }
            return _cannonList.Remove(cannon);
        }

        /// <summary>
        /// キャノンを取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ICannon GetCannon(string id)
        {
            ICannon cannon = _cannonList.Find(cannon => cannon.ID == id);
            if(cannon == null)
            {
                return null;
            }

            return cannon;
        }
    } // class CannonManager
}// namespace CannonShooting

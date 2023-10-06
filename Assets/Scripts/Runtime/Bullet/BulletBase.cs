using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamisFramework.Utility;

namespace CannonShooting
{
    /// <summary>
    /// 
    /// </summary>
    public class BulletBase : IBullet, ILifeSycleBase
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
        protected string _id = string.Empty;
        protected GameObject _root = null;
        protected eBulletType _bulletType = eBulletType.NONE;
        protected Rigidbody _rigidbody = null;
        protected Collider _collider = null;

        protected BulletContainer _bulletContainer = null;

        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================
        public string ID => _id;
        public GameObject Root => _root;
        public eBulletType BulletType => _bulletType;
        public Rigidbody RigidBody => _rigidbody;
        public Collider Collider => _collider;

        public Action<Collision> CollisionEnterAction { get; set; }
        public Action<Collision> CollisionStayAction { get; set; }
        public Action<Collision> CollisionExitAction { get; set; }

        //=====================================================================================================================
        // コンストラクタ
        //=====================================================================================================================
        public BulletBase(GameObject root, string id, eBulletType bulletType)
        {
            _root = root;
            _id = id;
            _bulletType = bulletType;
        }

        //=====================================================================================================================
        // ライフサイクル関数
        //=====================================================================================================================
        public virtual IEnumerator Initialize()
        {
            yield break;
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

        public virtual IEnumerator Termination()
        {
            yield break;
        }

        //=====================================================================================================================
        // Private関数
        //=====================================================================================================================

        //=====================================================================================================================
        // Public関数
        //=====================================================================================================================

    } // class BulletBase
}// namespace CannonShooting

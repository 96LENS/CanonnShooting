using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DynamisFramework.Utility;

namespace CannonShooting
{
    /// <summary>
    /// キャノンの基礎クラス
    /// </summary>
    public abstract class CannonBase : ICannon, ILifeSycleBase
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
        protected Animator _animator = null;
        protected Barrel _barrel = null;
        protected LowerCarriage _lowerCarriage = null;
        protected bool _isError = false;
        protected GameObject _bulletInstantiatePosition = null;

        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================
        public string ID => _id;
        public bool IsError => _isError;
        public GameObject BulletInstantiatePosition => _bulletInstantiatePosition;

        //=====================================================================================================================
        // コンストラクタ
        //=====================================================================================================================
        public CannonBase(string id, GameObject root)
        {
            _id = id;
            _root = root;

            _animator = root.GetComponent<Animator>();
            if(_animator == null)
            {
                Debug.LogError($"{_root.name}からAnimatorが見つかりませんでした");
            }

            CannonContainer container = _root.GetComponent<CannonContainer>();
            if(container == null)
            {
                Debug.LogError($"{_root.name}からCannonContainerが見つかりませんでした");
            }

            _barrel = new Barrel(container.Barrel.transform);
            _lowerCarriage = new LowerCarriage(container.LowerCarriage.transform);
            _bulletInstantiatePosition = container.BulletInstantiatePosition;
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
        public void RotateLowerCarriage(Vector3 value)
        {
            _lowerCarriage.Rotate(value);
        }

        public void RotateBarrel(Vector3 value)
        {
            _barrel.Rotate(value);
        }

    } // CannonBase
}// namespace CannonShooting

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DynamisFramework.Utility;

namespace CannonShooting
{
    /// <summary>
    /// システム制御用オブジェクトのアクセス保証クラス
    /// </summary>
    public class OperationRootContainer : DynamisFramework.Container.ContainerBase<OperationRootContainer>
    {
        //=====================================================================================================================
        // 内部クラス・列挙型定義
        //=====================================================================================================================

        //=====================================================================================================================
        // 定数
        //=====================================================================================================================

        //=====================================================================================================================
        // SerializeField変数
        //=====================================================================================================================
        [SerializeField]
        private GameObject _canvasBackground;
        [SerializeField]
        private GameObject _canvasMain;
        [SerializeField]
        private GameObject _canvasFront;
        [SerializeField]
        private GameObject _canvasForeground;

        [SerializeField]
        private GameObject _cameraRoot;
        [SerializeField]
        private GameObject _characterRoot;
        [SerializeField]
        private GameObject _pluginRoot;

        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================

        public GameObject CanvasBackground => _canvasBackground;
        public GameObject CanvasMain => _canvasMain;
        public GameObject CanvasFront => _canvasFront;
        public GameObject CanvasForeground => _canvasForeground;

        public GameObject CameraRoot => _cameraRoot;
        public GameObject CharacterRoot => _characterRoot;
        public GameObject PluginRoot => _pluginRoot;

        //=====================================================================================================================
        // MonoBehaviour関数
        //=====================================================================================================================
        protected override void Awake()
        {

        }

        //=====================================================================================================================
        // Private関数
        //=====================================================================================================================

        //=====================================================================================================================
        // Public関数
        //=====================================================================================================================

    } // class OperationRootContainer
}// namespace CannonShooting

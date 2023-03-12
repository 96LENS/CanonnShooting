namespace CannonShooting
{
    namespace Process
    {
        /// <summary>
        /// Processの管理単位
        /// 全てのプロセスはこのインターフェースを継承して実行されます
        /// </summary>
        public interface IGameProcess
        {
            //=====================================================================================================================
            // 関数
            //=====================================================================================================================
           
            /// <summary>
            /// 初期化
            /// </summary>
            void Initialize();

            /// <summary>
            /// Update前の更新
            /// </summary>
            void FixedUpdate();

            /// <summary>
            /// 更新処理
            /// </summary>
            void Update();

            /// <summary>
            /// 更新処理後の更新
            /// </summary>
            void LateUpdate();

            /// <summary>
            /// 解放
            /// </summary>
            void Destroy();

        } //class IGameProcessBase
    }//namespace Process
}//namespace CannonShooting

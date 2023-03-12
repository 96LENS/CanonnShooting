using UnityEngine;

namespace CannonShooting
{
    namespace Utility
    {
        /// <summary>
        /// 時間計測用のクラス
        /// </summary>
        public static class TimeMeasurement
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
            private static float _startTime = 0f;
            private static float _lastCountTime = 0f;
            private static float _totalTime = 0f;

            //=====================================================================================================================
            // プロパティ
            //=====================================================================================================================

            //=====================================================================================================================
            // Private関数
            //=====================================================================================================================

            /// <summary>
            /// 最後にこの関数を呼び出してから次にこの関数を呼び出す間の時間を返す
            /// </summary>
            /// <returns></returns>
            private static float _GetSubTotalTime()
            {
                float now = Time.realtimeSinceStartup;
                _lastCountTime = Time.realtimeSinceStartup - _lastCountTime;
                return _lastCountTime;
            }

            /// <summary>
            /// 計測開始時からこの関数呼び出し時までの時間を返す
            /// </summary>
            /// <returns></returns>
            private static float _GetTotalTime()
            {
                float now = Time.realtimeSinceStartup;
                _totalTime = now - _startTime;
                return _totalTime;
            }

            //=====================================================================================================================
            // Public関数
            //=====================================================================================================================
            /// <summary>
            /// 時間計測開始時に呼び出す関数(開始時刻を記録します)
            /// </summary>
            public static void StartTimeMeasurement()
            {
                _startTime = Time.realtimeSinceStartup;
            }

            /// <summary>
            /// 計測後から次にこの関数を呼び出した時までの時間を返す関数
            /// </summary>
            /// <param name="color">ログに表示したいテキストの色</param>
            /// <returns></returns>
            public static string GetSubTotalTimeToString()
            {
                return $"<color=orange>[SUB TOTAL] : {string.Format("{0:0.000}", _GetSubTotalTime())}Sec </color>";
            }

            /// <summary>
            ///  計測開始時からこの関数呼び出し時までの時間を返す
            /// </summary>
            /// <param name="color">ログに表示したいテキストの色</param>
            /// <returns></returns>
            public static string GetTotalTimeToString()
            {
                return $"<color=orange>[TOTAL] : {string.Format("{0:0.000}", _GetTotalTime())} Sec </color>";
            }

        } //class TimeMeasurement
    }//namespace Utility
}//namespace CannonShooting

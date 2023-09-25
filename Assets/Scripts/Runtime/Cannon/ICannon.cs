using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>

namespace CannonShooting
{
    public interface ICannon
    {
        //=====================================================================================================================
        // プロパティ
        //=====================================================================================================================
        string ID { get; }
        GameObject BulletInstantiatePosition { get; }

        //=====================================================================================================================
        // 関数
        //=====================================================================================================================

        /// <summary>
        /// 台座の回転
        /// </summary>
        void RotateLowerCarriage(Vector3 value);

        /// <summary>
        /// 砲台の回転
        /// </summary>
        void RotateBarrel(Vector3 value);

    } // ICannon
}// namespace CannonShooting

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// MonoBehaviourのルーチンを実装するためのインターフェース
/// </summary>
interface IMonoBehaviourRoutine
{
    //=====================================================================================================================
    // 提供する関数
    //=====================================================================================================================
    void Awake();

    void OnEnable();

    void Start();

    void FixedUpdate();

    void Update();

    void LateUpdate();

    void OnDisable();

    void OnDestroy();

} // IMonoBehaviour

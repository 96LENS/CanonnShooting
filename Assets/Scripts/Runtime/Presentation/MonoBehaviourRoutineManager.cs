using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// MonoBehaviourのルーチンを管理するクラス
/// </summary>
public class MonoBehaviourRoutineManager : ComponentBase
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
    private List<IMonoBehaviourRoutine> _updateRoutineList;

    //=====================================================================================================================
    // プロパティ
    //=====================================================================================================================

    //=====================================================================================================================
    // コンストラクタ
    //=====================================================================================================================

    //=====================================================================================================================
    // MonoBehaviour関数
    //=====================================================================================================================

　　private new void Awake()
    {
        base.Awake();

        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach(var routine in _updateRoutineList)
        {
            routine.Awake();
        }
    }

　　private void OnEnable()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.OnEnable();
        }

    }

　　private void Start()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.Start();
        }
    }

    private void FixedUpdate()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.FixedUpdate();
        }
    }

    
    private void Update()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.Update();
        }
    }

    private void LateUpdate()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.FixedUpdate();
        }
    }

    private void OnDisable()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.OnDisable();
        }
    }

    private new void OnDestroy()
    {
        if (_updateRoutineList.IsNullOrEmpty() == true) return;

        foreach (var routine in _updateRoutineList)
        {
            routine.OnDestroy();
        }

        _updateRoutineList.Clear();
        base.OnDestroy();
    }

    //=====================================================================================================================
    // public関数
    //=====================================================================================================================

    //=====================================================================================================================
    // Public関数
    //=====================================================================================================================


} // MonoBehaviourRoutineManager

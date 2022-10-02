using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Hierarchyに存在するオブジェクト用シングルトン
/// </summary>
public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour 
{
    //=====================================================================================================================
    // 変数
    //=====================================================================================================================
    private static T _instance = null;
    private static bool _isInstantiated = false;

    //=====================================================================================================================
    // プロパティ
    //=====================================================================================================================
    public static T Instance { get { return _instance; } }
    public static bool IsInitialized { get { return _isInstantiated; } }

    //=====================================================================================================================
    // MonoBehaviour関数
    //=====================================================================================================================

    /// <summary>
    /// インスタンス生成
    /// </summary>
    protected virtual void Awake()
    {
        _instance = GetComponent<T>();

        if (_instance != null)
        {
            _isInstantiated = true;
            Debug.Log($"<color=green>[{this.gameObject.name}]</color> instance created.");
        }
    }

    /// <summary>
    /// インスタンス解放
    /// </summary>
    protected virtual void OnDestroy()
    {
        _instance = null;
        _isInstantiated = false;
        Debug.Log($"<color=green>[{this.gameObject.name}]</color> instance released.");
    }

} // MonoBehaviourSingleton

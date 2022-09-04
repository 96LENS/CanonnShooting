using System;

/// <summary>
/// シングルトンを生成するクラス
/// </summary>
public abstract class Singleton<T> where T : class
{
    //=====================================================================================================================
    // 変数
    //=====================================================================================================================
    private static T _instance = null;
    private static bool _isInstantiated = false;

    //=====================================================================================================================
    // プロパティ
    //=====================================================================================================================
    public static T Istance { get { return _instance; } }
    public static bool IsInstantiated { get { return _isInstantiated; } }

    //=====================================================================================================================
    // Public関数
    //=====================================================================================================================
    
    /// <summary>
    /// インスタンス生成
    /// </summary>
    public static void CreateInstance()
    {
        if (_isInstantiated == true)
        {
            return;
        }

        var type = typeof(T);
        var obj = Activator.CreateInstance(type, true);
        _instance = obj as T;
        _isInstantiated = true;
    }

    /// <summary>
    /// インスタンス解放
    /// </summary>
    public virtual void OnDestroy()
    {
        _instance = null;
        _isInstantiated = false;
    }

} // Singleton

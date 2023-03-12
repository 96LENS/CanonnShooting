using System;
using System.Reflection;
using UnityEngine;

using CannonShooting.Utility;

/// <summary>
/// GameObjectを格納するコンポーネント
/// </summary>
public abstract class ContainerBase : SingletonMonoBehaviour<ContainerBase>
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

    //=====================================================================================================================
    // プロパティ
    //=====================================================================================================================

    //=====================================================================================================================
    // Private関数
    //=====================================================================================================================
    protected override void Awake()
    {
        if(IsSerializedFieldNullOrEmpty() == true)
        {
            return;
        }
    }

    protected override void OnDestroy()
    {
        
    }

    //=====================================================================================================================
    // Public関数
    //=====================================================================================================================
    
    /// <summary>
    /// 変数がNullまたは要素がないか(アタッチされていないか)を確認します
    /// </summary>
    private bool IsSerializedFieldNullOrEmpty()
    {
        var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.Static; 
        Type type = this.GetType();
        FieldInfo[] fields = type.GetFields(flags);

        // Debug.Log($"flags => {flags}, Type => {type}, FieldInfo[] => {fields.Length}");

        if (fields.IsNullOrEmpty())
        {
            Debug.LogError($"<color=red>[ContainerBase]</color> fields is null or empty. Please check <color=orange>{this.name}</color>.");
            return true;
        }

        foreach(var f in fields)
        {
            var value = f.GetValue(this);
            var attribute = f.GetCustomAttribute<SerializeField>();
            
            Debug.Log($"Name => {f.Name}, Value => {value}, Judge => {value is null}");
            
            if (attribute != null && value is null)
            {
                Debug.LogError($"<color=red>[ContainerBase]</color> => {f.Name} is null. Please check <color=orange>{this.name}</color>.");
                return true;
            }
        }

        return false;
    }

} // ContainerBase
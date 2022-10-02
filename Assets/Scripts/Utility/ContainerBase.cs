using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

/// <summary>
/// GameObjectを格納するコンポーネント
/// </summary>
public abstract class ContainerBase : MonoBehaviourSingleton<ContainerBase>
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
        base.Awake();

        if(IsSerializedFieldNullOrEmpty() == true)
        {
            Debug.LogErrorFormat("[{0}]メンバーへの参照が切れている場所があります。Containerのメンバーを確認してください", this.name);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
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

        if (fields.IsNullOrEmpty() == true)
        {
            Debug.LogError($"メンバーがNullまたは要素数が「0」です");
            return true;
        }

        foreach(var f in fields)
        {
            var value = f.GetValue(this);
            var attribute = f.GetCustomAttribute<SerializeField>();
            
            Debug.Log($"Name => {f.Name}, Value => {value}, Judge => {value is null}");
            
            if (attribute != null && value is null)
            {
                Debug.LogError($"{f.Name}の中身がありません。[{this.name}]コンポーネントを確認してください");
                return true;
            }
        }

        return false;

    }

} // ContainerBase
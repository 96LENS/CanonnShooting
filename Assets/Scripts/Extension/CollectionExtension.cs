using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// コレクションクラスの拡張
/// </summary>
public static class CollectionExtension
{
    //=====================================================================================================================
    // 拡張関数
    //=====================================================================================================================

    /// <summary>
    /// コレクションがnullか要素数が「0」かを判定します
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this ICollection self)
    {
        if (self == null) 
            return true;
        if (self.Count == 0) 
            return true;
        return false;
    }

} // CollectionExtension

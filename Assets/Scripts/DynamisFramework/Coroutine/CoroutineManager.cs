using System.Collections;
using UnityEngine;

namespace DynamisFramework
{
    namespace Coroutine
    {
        public class CoroutineManager : Utility.SingletonMonoBehaviour<CoroutineManager>
        {
            //=====================================================================================================================
            // ��`�E�萔
            //=====================================================================================================================

            //=====================================================================================================================
            // �ϐ�
            //=====================================================================================================================

            //=====================================================================================================================
            // �v���p�e�B
            //=====================================================================================================================

            //=====================================================================================================================
            // Public�֐�
            //=====================================================================================================================
            public static new UnityEngine.Coroutine StartCoroutine(IEnumerator routine)
            {
                var component = (MonoBehaviour)Instance;
                if(component == null)
                {
                    return null;
                }

                return component.StartCoroutine(routine);
            }

            public static void StopCoroutineSelf(UnityEngine.Coroutine coroutine)
            {
                var component = (MonoBehaviour)Instance;
                if(component == null)
                {
                    return;
                }

                component.StopCoroutine(coroutine);
            }
        }
    }
}

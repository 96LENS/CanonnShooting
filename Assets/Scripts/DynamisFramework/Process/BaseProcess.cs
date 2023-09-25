#define BASE_PROCESS_LOG
using System.Collections;
using UnityEngine;

using DynamisFramework.Coroutine;

namespace DynamisFramework
{
    namespace Process
    {
        /// <summary>
        /// Processの基礎クラス
        /// </summary>
        public abstract class BaseProcess
        {
            //=====================================================================================================================
            // 定義・定数
            //=====================================================================================================================
            
            /// <summary> プロセスのステータス定義 </summary>
            public enum eState : int
            { 
                None = 0,
                InitializeBefore,
                Initialize,
                InitializeAfter,
                Operate,
                TerminateBefore,
                Terminate,
                TerminateAfter
            }


            //=====================================================================================================================
            // 変数
            //=====================================================================================================================
            private eState _state = eState.None;
            private UnityEngine.Coroutine _currentCoroutine = null;
            private bool _changeRoot = false;
            private bool _isRequestTermination = false;

            private BaseProcess _nextProcess = null;
            private BaseProcess _parentProcess = null;
            private BaseProcess _childProcess = null;

            //=====================================================================================================================
            // プロパティ
            //=====================================================================================================================
            public abstract string Name { get; }
            public BaseProcess NextProcess { get => _nextProcess; }
            public BaseProcess ChildProcess
            { 
                get => _childProcess; 
                protected set => _childProcess = value; 
            }
            /// <summary> プロセス終了のリクエストが来ているか </summary>
            public bool IsRequestTermination
            { 
                get => _isRequestTermination; 
                private set => _isRequestTermination = value; 
            }

            /// <summary> 現在のプロセスか </summary>
            public bool IsCurrent { get; private set; }

            /// <summary> プロセスが実行のステータスか </summary>
            public bool IsOperate
            {
                get { return _state == eState.Operate; } 
            }


            //=====================================================================================================================
            // コンストラクタ
            //=====================================================================================================================
            protected BaseProcess()
            {

            }

            //=====================================================================================================================
            // Private関数
            //=====================================================================================================================
            /// <summary>
            /// 初期化前処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessInitializeBefore()
            {
                // 自身を初期化
                yield return CoroutineManager.StartCoroutine(_InitializeBefore());
                
                // 子がある場合は子を初期化
                if(_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(ChildProcess._ProcessInitializeBefore());
                }

                _state = eState.Initialize;
                _currentCoroutine = null;
            }

            /// <summary>
            /// 初期化処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessInitialize()
            {
                // 自身を初期化
                yield return CoroutineManager.StartCoroutine(_Initialize());

                // 子がある場合は子を初期化
                if (_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(ChildProcess._ProcessInitialize());
                }

                _state = eState.InitializeAfter;
                _currentCoroutine = null;
            }

            /// <summary>
            /// 初期化後処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessInitializeAfter()
            {
                yield return CoroutineManager.StartCoroutine(_InitializeAfter());

                // 子がある場合は子を初期化
                if (_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(ChildProcess._ProcessInitializeAfter());
                }

                _state = eState.Operate;
                _changeRoot = false;
                _currentCoroutine = null;
            }

            /// <summary>
            /// 解放前処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessTerminateBefore()
            {
                yield return CoroutineManager.StartCoroutine(_TerminateBefore());

                // 子がある場合は子を初期化
                if (_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(_childProcess._ProcessTerminateBefore());
                }

                if(_nextProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(_nextProcess._ProcessInitializeBefore());
                }

                _state = eState.Terminate;
                _currentCoroutine = null;
            }

            /// <summary>
            /// 解放処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessTerminate()
            {
                yield return CoroutineManager.StartCoroutine(_Terminate());

                // 子がある場合は子を初期化
                if (_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(ChildProcess._ProcessTerminate());
                }

                _state = eState.TerminateAfter;
                _currentCoroutine = null;
            }

            /// <summary>
            /// 解放後処理
            /// </summary>
            /// <returns></returns>
            private IEnumerator _ProcessTerminateAfter()
            {
                yield return CoroutineManager.StartCoroutine(_TerminateAfter());

                // 子がある場合は子を初期化
                if (_childProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(ChildProcess._ProcessTerminateAfter());
                }

                if(_nextProcess != null)
                {
                    yield return CoroutineManager.StartCoroutine(_nextProcess._ProcessInitializeAfter());

                    if(_parentProcess != null)
                    {
                        _parentProcess._childProcess = _nextProcess;
                        _nextProcess._parentProcess = _parentProcess;
                    }

                    if (_nextProcess.IsCurrent)
                    {
                        ProcessManager.Instance.SetCurrentProcess(_nextProcess);
                    }
                }

                else
                {
                    if(_parentProcess != null)
                    {
                        _parentProcess._childProcess = null;
                    }
                }

                _state = eState.Operate;
                _changeRoot = false;
                _nextProcess = null;
                _childProcess = null;
                _currentCoroutine = null;
            }


            //=====================================================================================================================
            // Public関数
            //=====================================================================================================================
            
            /// <summary>
            /// 定期更新処理
            /// </summary>
            public void FixedUpdate()
            {
                if(_state == eState.InitializeAfter || 
                   _state == eState.TerminateBefore ||
                   _state == eState.Operate)
                {
                    _FixedUpdate();
                }

                if(_childProcess != null)
                {
                    _childProcess.FixedUpdate();
                }
            }

            /// <summary>
            /// 毎フレーム更新処理
            /// 各プロセスのEnumeratorを切り替え
            /// </summary>
            public void Update()
            {
                if (_state == eState.None) return;

                if (_changeRoot)
                {
                    switch (_state)
                    {
                        case eState.InitializeBefore:
                            if(_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessInitializeBefore());
                            }
                            break;
                        case eState.Initialize:
                            if(_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessInitialize());
                            }
                            break;
                        case eState.InitializeAfter:
                            if (_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessInitializeAfter());
                            }
                            break;
                        case eState.TerminateBefore:
                            if (_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessTerminateBefore());
                            }
                            break;
                        case eState.Terminate:
                            if (_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessTerminate());
                            }
                            break;
                        case eState.TerminateAfter:
                            if (_currentCoroutine == null)
                            {
                                _currentCoroutine = CoroutineManager.StartCoroutine(_ProcessTerminateAfter());
                            }
                            break;

                    }
                }

                if(_state == eState.InitializeAfter ||
                   _state == eState.TerminateBefore || 
                   _state == eState.Operate)
                {
                    _Update();
                }

                if(_childProcess != null)
                {
                    _childProcess.Update();
                }
            }

            /// <summary>
            /// 更新後処理
            /// </summary>
            public void LateUpdate()
            {
                if (_state == eState.InitializeAfter ||
                    _state == eState.TerminateBefore ||
                    _state == eState.Operate)
                {
                    _LateUpdate();
                }

                if (_childProcess != null)
                {
                    _childProcess.LateUpdate();
                }
            }


            //=====================================================================================================================
            // Process関数
            //=====================================================================================================================
            /// <summary> 初期化前 </summary>
            protected virtual IEnumerator _InitializeBefore() { yield break; }
            /// <summary> 初期化 </summary>
            protected virtual IEnumerator _Initialize() { yield break; }
            /// <summary> 初期化後 </summary>
            protected virtual IEnumerator _InitializeAfter() { yield break; }
            /// <summary> 定期更新 </summary>
            protected virtual void _FixedUpdate() { }
            /// <summary> 毎フレーム更新 </summary>
            protected virtual void _Update() { }
            /// <summary> Update関数後更新 </summary>
            protected virtual void _LateUpdate() { }
            /// <summary> 放棄前 </summary>
            protected virtual IEnumerator _TerminateBefore() { yield break; }
            /// <summary> 放棄 </summary>
            protected virtual IEnumerator _Terminate() { yield break; }
            /// <summary> 放棄後 </summary>
            protected virtual IEnumerator _TerminateAfter() { yield break; }
        } //class BaseProcess

    }//namespace Process
}//namespace CannonShooting

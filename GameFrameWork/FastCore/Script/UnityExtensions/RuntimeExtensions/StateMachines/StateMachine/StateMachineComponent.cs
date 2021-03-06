﻿using System;
using UnityEngine;

namespace UnityExtensions
{
    /// <summary>
    /// 状态机组件, 可作为一般状态机或子状态机使用
    /// </summary>
    /// <typeparam name="T"> 状态类型 </typeparam>
    public class StateMachineComponent<T> : ScriptableComponent, IState where T : class, IState
    {
        T _currentState;
        double _currentStateTime;


        /// <summary>
        /// 当前状态持续时间
        /// </summary>
        public float currentStateTime
        {
            get { return (float)_currentStateTime; }
        }


        /// <summary>
        /// 当前状态持续时间
        /// </summary>
        public double currentStateTimeDouble
        {
            get { return _currentStateTime; }
        }


#if DEBUG
        bool _duringSetting = false;
#endif


        /// <summary>
        /// 当前状态
        /// </summary>
        public T currentState
        {
            get { return _currentState; }
            set
            {
#if DEBUG
                if (_duringSetting)
                {
                    throw new Exception("Shouldn't change state inside OnExit, OnEnter or stateChanged event!");
                }
                _duringSetting = true;
#endif

                _currentState?.OnExit();

                T previousState = _currentState;
                _currentState = value;
                _currentStateTime = 0;

                _currentState?.OnEnter();

                OnStateChanged(previousState, _currentState);

#if DEBUG
                _duringSetting = false;
#endif
            }
        }


        /// <summary>
        /// 状态变化后触发
        /// </summary>
        protected virtual void OnStateChanged(T lastState, T currentState)
        {
        }


        /// <summary>
        /// 作为子状态机使用时需要实现此方法
        /// </summary>
        public virtual void OnEnter() { }


        /// <summary>
        /// 作为子状态机使用时需要实现此方法
        /// </summary>
        public virtual void OnExit() { }


        /// <summary>
        /// 更新当前状态
        /// 注意: 顶层状态机需要主动调用
        /// </summary>
        public virtual void OnUpdate(float deltaTime)
        {
            _currentStateTime += deltaTime;
            _currentState?.OnUpdate(deltaTime);
        }

    } // class StateMachineComponent<T>


    [AddComponentMenu("Unity Extensions/State Machines/State Machine")]
    [DisallowMultipleComponent]
    public class StateMachineComponent : StateMachineComponent<BaseStateComponent>
    {
    }

} // namespace UnityExtensions

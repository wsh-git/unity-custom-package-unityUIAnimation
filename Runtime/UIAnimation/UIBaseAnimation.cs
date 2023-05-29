using System;
using UnityEngine;
using Wsh.UIAnimation.Easing;

namespace Wsh.UIAnimation {

    public class UIBaseAnimation : MonoBehaviour {
        private static int targetFrame = 30;
        private static float targetDeltaTime = 1f / targetFrame;
        private static bool inited = false;

        public EasingType easingType = EasingType.IN_SINE;
        public UIAnimationPlayType playType = UIAnimationPlayType.Once;
        public bool isInit;
        public int group;
        public float from;
        public float to;
        public float delay;
        public float duration;

        public event Action onFinish;

        public bool IsPlaying { get { return m_state == UIAnimationState.Play; } }

        protected int m_loopTimes = 0;
        protected UIAnimationState m_state;
        protected float m_playTime;
        protected float m_delayTime;
        protected float m_executeParam;
        protected float m_executeValue;
        private float m_valueExtent;
        private float m_timeRatio;
        private float m_playLoopTimes = 0;

        public static void SetTargetFrame(int frame) {
            if(!inited) {
                if(frame == -1) {
                    targetFrame = 60;
                } else {
                    targetFrame = frame;
                }
                targetDeltaTime = 1f / targetFrame;
                inited = true;
            }
        }

        private void SetState(UIAnimationState state) {
            m_state = state;
        }

        [ContextMenu("Execute")]
        public virtual void Play() {
            m_playLoopTimes = 0;
            m_executeParam = 0;
            m_playTime = 0;
            m_delayTime = 0;
            SetState(UIAnimationState.Delay);
            m_timeRatio = 1 / duration;
            m_valueExtent = to - from;
        }

        protected virtual void OnPlay() {

        }

        protected virtual void OnInit() {

        }

        protected virtual void OnUpdate(float deltaTime, float easingValue, float executeResult) {

        }

        void Start() {
            SetTargetFrame(Application.targetFrameRate);
            OnInit();
        }

        public void SetLoopTimes(int times) {
            m_loopTimes = times;
        }

        private bool ReplayPingPang() {
            m_executeParam = 0;
            m_playTime = 0;
            float temp = to;
            to = from;
            from = temp;
            m_valueExtent = to - from;
            m_playLoopTimes++;
            if(m_loopTimes != 0) {
                return m_playLoopTimes < m_loopTimes;
            }
            return true;
        }

        private bool ReplayLoop() {
            m_executeParam = 0;
            m_playTime = 0;
            m_playLoopTimes++;
            if(m_loopTimes != 0) {
                return m_playLoopTimes < m_loopTimes;
            }
            return true;
        }

        void Update() {
            switch(m_state) {
                case UIAnimationState.Delay:
                    m_delayTime += targetDeltaTime;
                    if(m_delayTime >= delay) {
                        OnPlay();
                        SetState(UIAnimationState.Play);
                    }
                    break;
                case UIAnimationState.Play:
                    m_playTime += targetDeltaTime;
                    m_executeParam = m_playTime * m_timeRatio;
                    m_executeValue = EasingFunctions.Excute(m_executeParam, easingType);
                    //m_executeValue *= m_valueExtent;
                    OnUpdate(targetDeltaTime, m_executeValue, (m_executeValue*m_valueExtent)+from);
                    if(m_playTime >= duration) {
                        switch(playType) {
                            case UIAnimationPlayType.PingPang:
                                if(!ReplayPingPang()){
                                    SetState(UIAnimationState.Finish);
                                    onFinish?.Invoke();
                                }
                                break;
                            case UIAnimationPlayType.Loop:
                                if(!ReplayLoop()) {
                                    SetState(UIAnimationState.Finish);
                                    onFinish?.Invoke();
                                }
                                break;
                            default:
                                SetState(UIAnimationState.Finish);
                                onFinish?.Invoke();
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
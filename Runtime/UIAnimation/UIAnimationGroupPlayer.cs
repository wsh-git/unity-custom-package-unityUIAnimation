using UnityEngine;

namespace Wsh.UIAnimation {

    public class UIAnimationGroupPlayer : MonoBehaviour {

        public int group;
        private UIBaseAnimation[] m_uiAnis;
        private float m_duration;

        public float Duration {
            get {
                 return m_duration;
            }
        }

        void InitUIAnis() {
            m_uiAnis = gameObject.GetComponentsInChildren<UIBaseAnimation>();
        }

        void CalcDuration() {
            m_duration = 0;
            if(m_uiAnis != null && m_uiAnis.Length > 0) {
                for(int i = 0; i < m_uiAnis.Length; i++) {
                    if(m_uiAnis[i].group == group) {
                        float dur = m_uiAnis[i].duration + m_uiAnis[i].delay;
                        if(m_duration < dur) {
                            m_duration = dur;
                        }
                    }
                }
            }
        }

        void Start() {
            InitUIAnis();
            CalcDuration();
        }

        [ContextMenu("Execute")]
        private void DebugPlay() {
            InitUIAnis();
            Play();
        }

        public void Play() {
            if(group != 0) {
                if(m_uiAnis != null && m_uiAnis.Length > 0) {
                    for(int i = 0; i < m_uiAnis.Length; i++) {
                        if(m_uiAnis[i].group == group) {
                            m_uiAnis[i].Play();
                        }
                    }
                }
            }
        }
    }
}
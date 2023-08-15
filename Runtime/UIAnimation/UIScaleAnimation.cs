using UnityEngine;

namespace Wsh.UIAnimation {

    public class UIScaleAnimation : UIBaseAnimation {

        [SerializeField]
        private bool m_isHorizontal;
        [SerializeField]
        private bool m_isVertical;
        private Vector3 m_tempVect3;
        private Vector3 m_originScale;

        protected override void OnInit() {
            m_tempVect3 = Vector3.one;
            m_originScale = transform.localScale;
            if(isInit) {
                SetScale(from);
            }
        }

        private void SetScale(float scale) {
            if(m_isHorizontal && m_isVertical) {
                m_tempVect3.Set(scale, scale, m_tempVect3.z);
            } else if(m_isHorizontal) {
                m_tempVect3.Set(scale, m_originScale.y, m_tempVect3.z);
            } else if(m_isVertical) {
                m_tempVect3.Set(m_originScale.x, scale, m_tempVect3.z);
            }
            transform.localScale = m_tempVect3;
        }

        protected override void OnPlay() {
            SetScale(from);
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetScale(executeResult);
        }

    }

}
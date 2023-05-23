using UnityEngine;

namespace Wsh.UIAnimation {

    public class UIScaleAnimation : UIBaseAnimation {

        private Vector3 m_tempVect3;

        protected override void OnInit() {
            m_tempVect3 = Vector3.one;
            if(isInit) {
                SetScale(from);
            }
        }

        private void SetScale(float scale) {
            m_tempVect3.Set(scale, scale, m_tempVect3.z);
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
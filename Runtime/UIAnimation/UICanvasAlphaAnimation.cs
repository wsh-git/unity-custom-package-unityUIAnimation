using UnityEngine;

namespace Wsh.UIAnimation {

    [RequireComponent(typeof(CanvasGroup))]
    public class UICanvasAlphaAnimation : UIBaseAnimation {
        private CanvasGroup m_canvasGroup;

        protected override void OnInit() {
            m_canvasGroup = transform.GetComponent<CanvasGroup>();
            if(isInit) {
                SetAlpha(from);
            }
        }

        private void SetAlpha(float alpha) {
            m_canvasGroup.alpha = alpha;
        }

        protected override void OnPlay() {
            SetAlpha(from);
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetAlpha(executeResult);
        }
    }
}
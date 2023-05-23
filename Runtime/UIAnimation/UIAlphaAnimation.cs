using UnityEngine;
using UnityEngine.UI;

namespace Wsh.UIAnimation {

    [RequireComponent(typeof(Graphic))]
    public class UIAlphaAnimation : UIBaseAnimation {
        
        private Graphic m_graphic;
        private Color m_color;

        protected override void OnInit() {
            m_graphic = transform.GetComponent<Graphic>();
            m_color = m_graphic.color;
            if(isInit) {
                SetAlpha(from);
            }
        }

        private void SetAlpha(float alpha) {
            m_color.a = alpha;
            m_graphic.color = m_color;
        }

        protected override void OnPlay() {
            SetAlpha(from);
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetAlpha(executeResult);
        }
    }
}
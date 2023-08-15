using UnityEngine;

namespace Wsh.UIAnimation {

    public class UISizeAnimation : UIBaseAnimation {
        
        [SerializeField]
        private bool m_isHorizontal;
        [SerializeField]
        private bool m_isVertical;
        [SerializeField]
        private Vector2 fromVect2;
        [SerializeField]
        private Vector2 toVect2;

        private float m_extentX;
        private float m_extentY;
        private Vector2 m_tempVect2;
        private Vector2 m_originSize;
        private RectTransform m_rectTransform;

        protected override void OnInit() {
            m_tempVect2 = Vector2.zero;
            m_rectTransform = transform.GetComponent<RectTransform>();
            m_originSize = m_rectTransform.sizeDelta;
            m_extentX = toVect2.x - fromVect2.x;
            m_extentY = toVect2.y - fromVect2.y;
            if(isInit) {
                SetSize(fromVect2.x, fromVect2.y);
            }
        }

        private void SetSize(float x, float y) {
            if(m_isHorizontal && m_isVertical) {
                m_tempVect2.Set(x, y);
            } else if(m_isHorizontal) {
                m_tempVect2.Set(x, m_originSize.y);
            } else if(m_isVertical) {
                m_tempVect2.Set(m_originSize.x, y);
            }            
            m_rectTransform.sizeDelta = m_tempVect2;
        }

        protected override void OnPlay() {
            m_tempVect2 = Vector2.zero;
            m_originSize = m_rectTransform.sizeDelta;
            SetSize(fromVect2.x, fromVect2.y);
            m_extentX = toVect2.x - fromVect2.x;
            m_extentY = toVect2.y - fromVect2.y;
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetSize(easingValue * m_extentX + fromVect2.x, easingValue * m_extentY + fromVect2.y);
        }
    
        public void SetFromVector2(Vector2 vector2) {
            fromVect2 = vector2;
        }

        public void SetToVector2(Vector2 vector2) {
            toVect2 = vector2;
        }

    }
}
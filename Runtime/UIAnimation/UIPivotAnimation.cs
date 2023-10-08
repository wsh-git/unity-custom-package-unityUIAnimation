using UnityEngine;

namespace Wsh.UIAnimation {
    
    public class UIPivotAnimation : UIBaseAnimation {

        public Vector2 FromVect2 { get { return m_fromVect2; } }
        public Vector2 ToVect2 { get { return m_toVect2; } }

        [SerializeField]private Vector2 m_fromVect2;
        [SerializeField]private Vector2 m_toVect2;
        private float m_extentX;
        private float m_extentY;
        private Vector2 m_tempVect2;
        private RectTransform m_rectTransform;
        private Vector2 m_tempChangeVector2;

        private void ClacExtent() {
            m_extentX = m_toVect2.x - m_fromVect2.x;
            m_extentY = m_toVect2.y - m_fromVect2.y;
        }

        protected override void OnInit() {
            m_tempVect2 = Vector2.zero;
            m_rectTransform = transform.GetComponent<RectTransform>();
            if(isInit) {
                SetPivot(m_fromVect2.x, m_fromVect2.y);
            }
            ClacExtent();
        }

        public void Set(Vector2 from, Vector2 to) {
            m_fromVect2 = from;
            m_toVect2 = to;
        }

        public void ResetFromVect3(Vector2 vector2) {
            m_fromVect2 = vector2;
            ClacExtent();
        }

        private void SetPivot(float x, float y) {
            m_tempVect2.Set(x, y);
            m_rectTransform.pivot = m_tempVect2;
        }

        protected override void OnPlay() {
            m_tempVect2 = Vector2.zero;
            SetPivot(m_fromVect2.x, m_fromVect2.y);
            ClacExtent();
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetPivot(easingValue * m_extentX + m_fromVect2.x, easingValue * m_extentY + m_fromVect2.y);
        }

        protected override void OnReplayPingPang() {
            m_tempChangeVector2 = m_toVect2;
            m_toVect2 = m_fromVect2;
            m_fromVect2 = m_tempChangeVector2;
            ClacExtent();
        }

    }

}

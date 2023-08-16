using UnityEngine;

namespace Wsh.UIAnimation {

    public class UIPositionAnimation : UIBaseAnimation {

        public Vector3 fromVect3;
        public Vector3 toVect3;

        private float m_extentX;
        private float m_extentY;
        private float m_extentZ;
        private Vector3 m_tempVect3;
        private RectTransform m_rectTransform;

        private void ClacExtent() {
            m_extentX = toVect3.x - fromVect3.x;
            m_extentY = toVect3.y - fromVect3.y;
            m_extentZ = toVect3.z - fromVect3.z;
        }

        protected override void OnInit() {
            m_tempVect3 = Vector3.zero;
            m_rectTransform = transform.GetComponent<RectTransform>();
            if(isInit) {
                SetPosition(fromVect3.x, fromVect3.y, fromVect3.z);
            }
            ClacExtent();
        }

        public void ResetFromVect3(Vector3 vector3) {
            fromVect3 = vector3;
            ClacExtent();
        }

        protected override void OnPlay() {
            m_tempVect3 = Vector3.zero;
            SetPosition(fromVect3.x, fromVect3.y, fromVect3.z);
            ClacExtent();
        }

        private void SetPosition(float x, float y, float z) {
            m_tempVect3.Set(x, y, z);
            m_rectTransform.anchoredPosition3D = m_tempVect3;
        }

        protected override void OnUpdate(float deltaTime, float easingValue, float executeResult) {
            SetPosition(easingValue * m_extentX + fromVect3.x, easingValue * m_extentY + fromVect3.y, easingValue * m_extentZ + fromVect3.z);
        }

    }

}

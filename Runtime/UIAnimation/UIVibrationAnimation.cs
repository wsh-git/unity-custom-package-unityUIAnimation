using UnityEngine;
using UnityEngine.Events;

namespace Wsh.UIAnimation {

    public class UIVibrationAnimation : MonoBehaviour {

        [SerializeField]
        private float m_delay;
        [SerializeField]
        private float m_intensity;
        [SerializeField]
        private float m_duration;
        [SerializeField]
        private UnityEvent onFinish;
        private float m_timer;
        private Vector3 m_originalPosition;
        private Vector3 m_tempVect3;
        private bool m_isStartPlay;
        private float m_delayUse;
        
        void Start() {
            m_tempVect3 = Vector3.zero;
        }

        [ContextMenu("Execute")]
        public void Play() {
            m_originalPosition = transform.localPosition;
            m_isStartPlay = true;
            m_timer = 0;
            m_delayUse = m_delay;
        }

        private void SetPosition(Vector3 position) {
            transform.localPosition = position;
        }

        private void UpdateVibrationPosition() {
            SetPosition(m_originalPosition + m_tempVect3);
        }

        private void RevertPosition() {
            SetPosition(m_originalPosition);
        }

        void Update() {
            if(m_isStartPlay) {
                UpdateVibration(Time.deltaTime);
            }
        }
    
        private void UpdateVibration(float deltaTime) {
            if(m_delayUse <= 0) {
                if(m_timer < m_duration) {
                    m_tempVect3.x = Random.Range(-m_intensity, m_intensity);
                    m_tempVect3.y = Random.Range(-m_intensity, m_intensity);
                    UpdateVibrationPosition();
                    m_timer += deltaTime;
                } else {
                    RevertPosition();
                    onFinish?.Invoke();
                    m_isStartPlay = false;
                }
            } else {
                m_delayUse -= deltaTime;
            }
        }

    }
}
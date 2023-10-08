using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wsh.UIAnimation {

    public class UIFrameSpriteAnimation : MonoBehaviour {

        [SerializeField] private Image m_image;
        [SerializeField] private float m_fps;
        [SerializeField] private bool m_loop;
        [SerializeField] private string m_animationName;
        [SerializeField] private List<FrameSpriteData> m_animationFrames;

        private int m_animationFrameIndex;
        private bool m_isPlaying;
        private float m_delta;
        private float m_rate;
        private FrameSpriteData m_currentFrameSpriteData;

        public void Play(string animationName) {
            if(m_image == null) {
                Debug.LogError("'UIFrameSpriteAnimation' dont have Component of 'Image'");
                return;
            }
            m_isPlaying = true;
            m_animationFrameIndex = 0;
            m_animationName = animationName;
            m_currentFrameSpriteData = GetFrameSpriteData(m_animationName);
        }

        [ContextMenu("Execute")]
        public void ExecuteTest() {
            Play(m_animationName);
        }

        private FrameSpriteData GetFrameSpriteData(string animationName) {
            var data = m_animationFrames.Find(x => x.AnimationName == animationName);
            if(data == null) {
                Debug.LogError("Dont find the frameSpriteData by " + animationName);
            }
            return data;
        }

        public void Stop() {
            m_isPlaying = false;
        }
        
        // Update is called once per frame
        void Update() {
            UpdateFrames();
        }

        private void UpdateFrames() {
            if(m_isPlaying&& Application.isPlaying && m_fps > 0) {
                m_delta += Mathf.Min(1f, Time.unscaledDeltaTime);
                m_rate = 1f / m_fps;
                while(m_rate < m_delta) {
                    m_delta = (m_rate > 0f) ? m_delta - m_rate : 0f;
                    if(++m_animationFrameIndex >= m_currentFrameSpriteData.Frames.Count) {
                        m_animationFrameIndex = 0;
                        m_isPlaying = m_loop;
                    }
                    if(m_isPlaying) {
                        m_image.sprite = m_currentFrameSpriteData.Frames[m_animationFrameIndex];
                    }
                }
            }
        }
    }
}
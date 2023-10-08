using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wsh.UIAnimation {

    [UnityEngine.Scripting.Preserve]
    [Serializable]
    public class FrameSpriteData {
        public string AnimationName;
        public List<Sprite> Frames;
    }
}
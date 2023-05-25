namespace Wsh.UIAnimation {

    public class UIAnimationUtils {
        public static float PlayAnimation(UIBaseAnimation[] anis, int aniGroup) {
            float duration = 0;
            if(anis != null && anis.Length > 0) {
                for(int i = 0; i < anis.Length; i++) {
                    var ani = anis[i];
                    if(ani.group == aniGroup) {
                        float currentDuration = ani.delay + ani.duration;
                        if(currentDuration > duration) {
                            duration = currentDuration;
                        }
                        ani.Play();
                    }
                }
            }
            return duration;
        }
    }

}
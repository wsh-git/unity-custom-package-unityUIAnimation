using UnityEngine;

namespace Wsh.UIAnimation.Easing {

    public class EasingFunctions {

        private const float c1 = 1.70158f;
        private const float c2 = c1 * 1.525f;
        private const float c3 = c1 + 1;
        private const float c4 = (2 * Mathf.PI) / 3f;
        private const float c5 = (2 * Mathf.PI) / 4.5f;
        private const float n1 = 7.5625f;
        private const float d1 = 2.75f;

        public static float Excute(float x, EasingType easeType) {
            if(easeType == EasingType.IN_SINE) {
                return InSine(x);
            } else if(easeType == EasingType.OUT_SINE) {
                return OutSine(x);
            } else if(easeType == EasingType.INOUT_SINE) {
                return InOutSine(x);
            } else if(easeType == EasingType.IN_QUAD) {
                return InQuad(x);
            } else if(easeType == EasingType.OUT_QUAD) {
                return OutQuad(x);
            } else if(easeType == EasingType.INOUT_QUAD) {
                return InOutQuad(x);
            } else if(easeType == EasingType.IN_CUBIC) {
                return InCubic(x);
            } else if(easeType == EasingType.OUT_CUBIC) {
                return OutCubic(x);
            } else if(easeType == EasingType.INOUT_CUBIC) {
                return InOutCubic(x);
            } else if(easeType == EasingType.IN_QUART) {
                return InQuart(x);
            } else if(easeType == EasingType.OUT_QUART) {
                return OutQuart(x);
            } else if(easeType == EasingType.INOUT_QUART) {
                return InOutQuart(x);
            } else if(easeType == EasingType.IN_QUINT) {
                return InQuint(x);
            } else if(easeType == EasingType.OUT_QUINT) {
                return OutQuint(x);
            } else if(easeType == EasingType.INOUT_QUINT) {
                return InOutQuint(x);
            } else if(easeType == EasingType.IN_EXPO) {
                return InExpo(x);
            } else if(easeType == EasingType.OUT_EXPO) {
                return OutExpo(x);
            } else if(easeType == EasingType.INOUT_EXPO) {
                return InOutExpo(x);
            } else if(easeType == EasingType.IN_CIRC) {
                return InCirc(x);
            } else if(easeType == EasingType.OUT_CIRC) {
                return OutCirc(x);
            } else if(easeType == EasingType.INOUT_CIRC) {
                return InOutCirc(x);
            } else if(easeType == EasingType.IN_BACK) {
                return InBack(x);
            } else if(easeType == EasingType.OUT_BACK) {
                return OutBack(x);
            } else if(easeType == EasingType.INOUT_BACK) {
                return InOutBack(x);
            } else if(easeType == EasingType.IN_ELASTIC) {
                return InElastic(x);
            } else if(easeType == EasingType.OUT_ELASTIC) {
                return OutElastic(x);
            } else if(easeType == EasingType.INOUT_ELASTIC) {
                return InOutElastic(x);
            } else if(easeType == EasingType.IN_BOUNCE) {
                return InBounce(x);
            } else if(easeType == EasingType.OUT_BOUNCE) {
                return OutBounce(x);
            } else if(easeType == EasingType.INOUT_BOUNCE) {
                return InOutBounce(x);
            } else if(easeType == EasingType.LINE) {
                return Line(x);
            }
            return x;
        }
    
        private static float Sqrt(float x) {
            return Mathf.Sqrt(x);
        }

        private static float Pow(float x, float y) {
            return Mathf.Pow(x, y);
        }

        private static float InSine(float x) {
            return 1 - Mathf.Cos((x * Mathf.PI) / 2);
        }

        private static float OutSine(float x) {
            return Mathf.Sin((x * Mathf.PI) / 2);
        }

        private static float InOutSine(float x) {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }

        private static float InQuad(float x) {
            return x * x;
        }

        private static float OutQuad(float x) {
            return 1 - (1 - x) * (1 - x);
        }

        private static float InOutQuad(float x) {
            return x < 0.5f ? 2 * x * x : 1 - Pow((-2 * x + 2), 2) / 2;
        }

        private static float InCubic(float x) {
            return x * x * x;
        }

        private static float OutCubic(float x) {
            return 1 - Pow(1 - x, 3);
        }

        private static float InOutCubic(float x) {
            return x < 0.5f ? 4 * x * x * x : 1 - Pow(-2 * x + 2, 3) / 2;
        }

        private static float InQuart(float x) {
            return x * x * x * x;
        }

        private static float OutQuart(float x) {
            return 1 - Pow(1 - x, 4);
        }
        
        private static float InOutQuart(float x) {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Pow(-2 * x + 2, 4) / 2;
        }

        private static float InQuint(float x) {
            return x * x * x * x * x;
        }

        private static float OutQuint(float x) {
            return 1 - Pow(1 - x, 5);
        }

        private static float InOutQuint(float x) {
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Pow(-2 * x + 2, 5) / 2;
        }

        private static float InExpo(float x) {
            return x == 0 ? 0 : Pow(2, 10 * x - 10);
        }

        private static float OutExpo(float x) {
            return x == 1 ? 1 : 1 - Pow(2, -10 * x);
        }

        private static float InOutExpo(float x) {
            return x == 0 ? 0 : (x == 1 ? 1 : (x < 0.5 ? Pow(2, 20 * x - 10) / 2 : (2 - Pow(2, -20 * x + 10)) / 2));
        }

        private static float InCirc(float x) {
            return 1 - Sqrt(1 - Pow(x, 2));
        }

        private static float OutCirc(float x) {
            return Sqrt(1 - Pow(x - 1, 2));
        }

        private static float InOutCirc(float x) {
            return x < 0.5f ? (1 - Sqrt(1 - Pow(2 * x, 2))) / 2 : (Sqrt(1 - Pow(-2 * x + 2, 2)) + 1) / 2;
        }

        private static float InBack(float x) {
            return c3 * x * x * x - c1 * x * x;
        }

        private static float OutBack(float x) {
            return 1 + c3 * Pow(x - 1, 3) + c1 * Pow(x - 1, 2);
        }

        private static float InOutBack(float x) {
            return x < 0.5 ? (Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 : (Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }
    
        private static float InElastic(float x) {
            return x == 0 ? 0 : (x == 1 ? 1 : -Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4));
        }

        private static float OutElastic(float x) {
            return x == 0 ? 0 : (x == 1 ? 1 : (Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1));
        }

        private static float InOutElastic(float x) {
            return x == 0
              ? 0
              : x == 1
              ? 1
              : x < 0.5f
              ? -(Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
              : (Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
        }

        private static float InBounce(float x) {
            return 1 - OutBounce(1 - x);
        }
    
        private static float OutBounce(float x) {
            if(x < 1 / d1) {
                return n1 * x * x;
            } else if(x < 2 / d1) {
                x = x - 1.5f;
                return n1 * (x / d1) * x + 0.75f;
            } else if(x < 2.5f / d1) {
                x = x - 2.25f;
                return n1 * (x / d1) * x + 0.9375f;
            } else {
                x = x - 2.625f;
                return n1 * (x / d1) * x + 0.984375f;
            }
        }

        private static float InOutBounce(float x) {
            //TODO:
            return 1;
            //return x < 0.5f ? (1 - EaseOutBounce(1 - 2 * x)) / 2 : (1 + EaseOutBounce(2 * x - 1)) / 2;
        }

        private static float Line(float x) {
            return x;
        }
    }
}
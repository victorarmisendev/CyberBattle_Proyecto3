using UnityEngine;

namespace Menuu {
    public class ShadowDistance : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = 0;
        }

        protected override void GraphicsPresetMedium() {
            Value = 35;
        }

        protected override void GraphicsPresetHigh() {
            Value = 70;
        }

        protected override void GraphicsPresetUltra() {
            Value = 100;
        }

        protected override void OnSliderValueChange() {
            SetShadowDistance(Value);
        }

        void SetShadowDistance(float value) {
            QualitySettings.shadowDistance = value;
        }
    }
}

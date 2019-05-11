using UnityEngine;

namespace Menuu {
    public class Vsync : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = 0;
        }

        protected override void GraphicsPresetMedium() {
            Value = 0;
        }

        protected override void GraphicsPresetHigh() {
            Value = 0;
        }

        protected override void GraphicsPresetUltra() {
            Value = 0;
        }

        protected override void OnSliderValueChange() {
            SetVsync(Value);
        }

        void SetVsync(int value) {
            QualitySettings.vSyncCount = value;
        }
    }
}

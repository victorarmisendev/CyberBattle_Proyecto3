using UnityEngine;

namespace Menuu {
    public class TextureQuality : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = 0;
        }

        protected override void GraphicsPresetMedium() {
            Value = 1;
        }

        protected override void GraphicsPresetHigh() {
            Value = 2;
        }

        protected override void GraphicsPresetUltra() {
            Value = 3;
        }

        protected override void OnSliderValueChange() {
            SetTextureQuality(Value);
        }

        void SetTextureQuality(int value) {
            // In the quality settings 0 is full quality textures, while 3 is the lowest.
            QualitySettings.masterTextureLimit = 3 - value;
        }
    }
}

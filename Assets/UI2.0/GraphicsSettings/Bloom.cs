using UnityEngine.PostProcessing;

namespace Menuu {
    public class Bloom : SliderBase {

        protected override void Start() {
            base.Start();
            displayValue.text = Value.ToString() + "%";
        }

        protected override void OnSliderValueChangeSetDisplayText() {
            if (Value == 0) {
                displayValue.text = "Off";
            }
            else {
                displayValue.text = Value.ToString() + "%";
            }
        }

        protected override void GraphicsPresetLow() {
            Value = 0;
        }

        protected override void GraphicsPresetMedium() {
            Value = 100;
        }

        protected override void GraphicsPresetHigh() {
            Value = 100;
        }

        protected override void GraphicsPresetUltra() {
            Value = 100;
        }

        protected override void OnSliderValueChange() {
            SetBloom(Value);
        }

        void SetBloom(float value) {
            BloomModel bloom = cam.GetComponent<PostProcessingBehaviour>().profile.bloom;

            BloomModel.Settings tempSettings = bloom.settings;
            tempSettings.bloom.intensity = 0.2f * (value / 100);
            bloom.settings = tempSettings;

            if (value <= 0) {
                bloom.enabled = false;
            }
            else {
                bloom.enabled = true;
            }
        }
    }
}

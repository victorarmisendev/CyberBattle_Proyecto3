using UnityEngine.PostProcessing;

namespace Menuu {
    public class Vignetting : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetMedium() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetHigh() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void GraphicsPresetUltra() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void OnSliderValueChange() {
            SetVignetting(System.Convert.ToBoolean(Value));
        }

        void SetVignetting(bool value) {
            cam.GetComponent<PostProcessingBehaviour>().profile.vignette.enabled = value;
        }
    }
}

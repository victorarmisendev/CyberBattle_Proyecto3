using UnityEngine.PostProcessing;

namespace Menuu {
    public class ChromaticAberration : SliderBase {

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
            SetChromaticAberration(System.Convert.ToBoolean(Value));
        }

        void SetChromaticAberration(bool value) {
            cam.GetComponent<PostProcessingBehaviour>().profile.chromaticAberration.enabled = value;
        }
    }
}

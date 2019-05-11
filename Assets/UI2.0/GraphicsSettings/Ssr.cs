using UnityEngine.PostProcessing;

namespace Menuu {
    public class Ssr : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetMedium() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetHigh() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetUltra() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void OnSliderValueChange() {
            SetSsr(System.Convert.ToBoolean(Value));
        }

        void SetSsr(bool value) {
            cam.GetComponent<PostProcessingBehaviour>().profile.screenSpaceReflection.enabled = value;
        }
    }
}

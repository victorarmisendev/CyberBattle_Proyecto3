using UnityEngine.PostProcessing;

namespace Menuu {
    public class Fog : SliderBase {

        protected override void GraphicsPresetLow() {
            Value = System.Convert.ToInt16(false);
        }

        protected override void GraphicsPresetMedium() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void GraphicsPresetHigh() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void GraphicsPresetUltra() {
            Value = System.Convert.ToInt16(true);
        }

        protected override void OnSliderValueChange() {
            SetFog(System.Convert.ToBoolean(Value));
        }

        void SetFog(bool value) {
            cam.GetComponent<PostProcessingBehaviour>().profile.fog.enabled = value;
        }
    }
}

using UnityEngine.PostProcessing;

namespace Menuu {
    public class AntiAliasing : SliderBase {

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
            SetAntiAliasing(Value);
        }

        void SetAntiAliasing(int value) {
            AntialiasingModel aa = cam.GetComponent<PostProcessingBehaviour>().profile.antialiasing;

            if (value == 2) {
                aa.enabled = true;
                AntialiasingModel.Settings tempSettings = aa.settings;
                tempSettings.method = AntialiasingModel.Method.Taa;
                aa.settings = tempSettings;
            }
            else if (value == 1) {
                aa.enabled = true;
                AntialiasingModel.Settings tempSettings = aa.settings;
                tempSettings.method = AntialiasingModel.Method.Fxaa;
                aa.settings = tempSettings;
            }
            else {
                aa.enabled = false;
            }
        }
    }
}

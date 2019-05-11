using UnityEngine;

namespace Menuu {
    public class FieldOfView : SliderBase {

        protected override void Start() {
            base.Start();
            SetFieldOfViewDisplayText();
        }

        protected override void GraphicsPresetLow() {
            Value = 60;
        }

        protected override void GraphicsPresetMedium() {
            Value = 60;
        }

        protected override void GraphicsPresetHigh() {
            Value = 60;
        }

        protected override void GraphicsPresetUltra() {
            Value = 60;
        }

        protected override void OnSliderValueChange() {
            cam.fieldOfView = Value;
        }

        protected override void OnSliderValueChangeSetDisplayText() {
            SetFieldOfViewDisplayText();
        }

        void SetFieldOfViewDisplayText() {
            float hFov = 2 * Mathf.Atan(cam.aspect * Mathf.Tan(Mathf.Deg2Rad * Value / 2));
            hFov *= Mathf.Rad2Deg;
            displayValue.text = Value.ToString() + " (" + hFov.ToString("0") + ")";
        }
    }
}

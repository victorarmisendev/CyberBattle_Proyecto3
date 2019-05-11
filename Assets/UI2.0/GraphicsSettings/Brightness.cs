namespace Menuu {
    public class Brightness : SliderBase {

        protected override void Start() {
            base.Start();
            displayValue.text = Value.ToString() + "%";
        }

        protected override void GraphicsPresetLow() {
            Value = 100;
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
            //cam.GetComponent<BrightnessEffect>().brightness = slider.value / 100f;
        }

        protected override void OnSliderValueChangeSetDisplayText() {
            displayValue.text = Value.ToString() + "%";
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace Menuu {
    public class SteppedSlider : MonoBehaviour {

        Slider slider;
        // The slider value as an int.
        int Value {
            get { return (int)slider.value; }
        }
        // The rect for the slider.
        Rect sliderRect;
        // The width of the handle.
        float handleWidth;
        // The number of steps for the slider.
        int sliderSteps;

        void Start() {
            // Get the slider.
            slider = GetComponent<Slider>();

            if (!slider.wholeNumbers) {
                Debug.LogError("The stepped slider only works with whole number sliders.");
                return;
            }

            // Attach the listener for the method we call when the slider value changes.
            slider.onValueChanged.AddListener(delegate { OnSliderValueChangeSetPosition(); });

            // Get the width of the slider.
            sliderRect = slider.GetComponent<RectTransform>().rect;

            // Calculate the total number of steps for the slider.
            sliderSteps = (int)slider.maxValue - (int)slider.minValue + 1;

            // Set the width of the handle.
            handleWidth = sliderRect.width / sliderSteps;
            slider.handleRect.sizeDelta = new Vector2(handleWidth, slider.handleRect.sizeDelta.y);

            // Set the initial handle position based on the slider value.
            SetHandlePosition(Value);
        }

        /**
         * OnChangeValue callback for the slider.
         */
        void OnSliderValueChangeSetPosition() {
            SetHandlePosition(Value);
        }

        /**
         * Set the handle to the correct position based on the slider value.
         */
        void SetHandlePosition(int value) {
            float xPosition = sliderRect.x + (handleWidth / 2) + handleWidth * (value - slider.minValue);
            slider.handleRect.localPosition = new Vector3(xPosition, slider.handleRect.localPosition.y, slider.handleRect.localPosition.z);
        }
    }
}

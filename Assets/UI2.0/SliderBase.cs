using UnityEngine;
using UnityEngine.UI;

namespace Menuu {
    public class SliderBase : MonoBehaviour {

        // The camera in use.
        protected Camera cam;
        // The text we display to the user for the slider value.
        protected Text displayValue;
        // The slider.
        protected Slider slider;
        // The slider value as an int.
        protected int Value {
            get { return (int)slider.value; }
            set { slider.value = System.Convert.ToInt16(value); }
        }

        bool changedByPreset;

        GraphicsSettings graphicsSettings;

        public string[] displayLabels;

        void Awake() {
            // Get the camera.
            cam = Camera.main;

            // Get the slider.
            slider = GetComponent<Slider>();

            // Register the graphics preset listeners.
            graphicsSettings = GameObject.Find("MainMenu").GetComponent<GraphicsSettings>();
            graphicsSettings.lowPresetEvent.AddListener(GraphicsPresetLow);
            graphicsSettings.mediumPresetEvent.AddListener(GraphicsPresetMedium);
            graphicsSettings.highPresetEvent.AddListener(GraphicsPresetHigh);
            graphicsSettings.ultraPresetEvent.AddListener(GraphicsPresetUltra);
        }

        protected virtual void Start() {
            // Attach the listener for the method we call when the slider value changes.
            slider.onValueChanged.AddListener(delegate { OnSliderValueChangeCheckPreset(); });
            slider.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
            slider.onValueChanged.AddListener(delegate { OnSliderValueChangeSetDisplayText(); });

            // Find the Text component for the display value.
            displayValue = transform.Find("Value").GetComponent<Text>();

            // Initialize it to the current slider value.
            displayValue.text = slider.value.ToString();

            if (displayLabels.Length > 0) {
                displayValue.text = displayLabels[Value];
            }
        }

        /**
         * The settings to apply when a preset is selected. Overriden in each
         * respective settings class. Here you can turn off an effect on a lower
         * quality setting or adjust some of it's values, lower shadow distance
         * perhaps or whatever you want.
         */
        protected virtual void GraphicsPresetLow() {
        }
        protected virtual void GraphicsPresetMedium() {
        }
        protected virtual void GraphicsPresetHigh() {
        }
        protected virtual void GraphicsPresetUltra() {
        }

        /**
         * Whenever we change a setting check to see if we're not in the custom
         * preset and if so change it so that we're in the custom preset. You're
         * not supposed to be able to change anything while having any other
         * preset selected.
         */
        protected virtual void OnSliderValueChangeCheckPreset() {
            if (graphicsSettings.presetSlider.value != 4 && !graphicsSettings.changedByPreset) {
                graphicsSettings.presetSlider.value = 4;
            }
        }

        /**
         * Each setting class overrides this and changes whatever it wants changed
         * when we modify the slider. For example turns on/off an image effect or
         * adjusts the volume in the audio mixer.
         */
        protected virtual void OnSliderValueChange() {
        }

        /**
         * Set the text value to display in the menu for this settings slider. A 
         * setting class can override this to display whatever it wants in the menu.
         */
        protected virtual void OnSliderValueChangeSetDisplayText() {
            if (displayLabels.Length > 0) {
                displayValue.text = displayLabels[Value];
            }
            else {
                displayValue.text = Value.ToString();
            }
        }
    }
}

using UnityEngine;

namespace Menuu
{
    public class Panel : MonoBehaviour
    {

        public UnityEngine.UI.Selectable firstSelected;

        /**
         * Select the specified element so that we can navigate through the panel
         * using a keyboard or gamepad.
         */
        public void SelectFirstElement()
        {
            firstSelected.Select();
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menuu
{
    public class PanelManager : SingletonManager<PanelManager>
    {
        public GameObject menu;
        public GameObject[] panels;

        // Used by the buttons which open panels so we can return to the same button
        // after closing the panel.
        [HideInInspector]
        public Button currentButton;

        // Used to determine which game object our mouse pointer is currently hovering over.
        [HideInInspector]
        public GameObject currentMouseOverGameObject;

        bool menuOpen = true;
        bool panelOpen = false;

        void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (panelOpen)
                {
                    HideAllPanels();
                }
                else if (menuOpen)
                {
                    HideMenu();
                }
                else
                {
                    ShowMenu();
                }
            }
        }

        public void GenericBackButton()
        {
            HideAllPanels();
        }

        void HideAllPanels()
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
            }
            panelOpen = false;
            ShowMenu();
            currentButton.Select();
        }

        public void ShowPanel(int id)
        {
            panels[id].SetActive(true);
            panels[id].GetComponent<Panel>().SelectFirstElement();
            panelOpen = true;
            HideMenu();
        }

        public void ShowMenu()
        {
            menu.SetActive(true);
            menuOpen = true;
        }
        public void HideMenu()
        {
            menu.SetActive(false);
            menuOpen = false;
        }

        public void Quit()
        {
            //If we are running in a standalone build of the game
#if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
#endif

            //If we are running in the editor
#if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

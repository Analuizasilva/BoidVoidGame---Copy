using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.AutoMode.PlayerAM
{
    public class PlayerButtonManager : MonoBehaviour
    {
        public PlayerAutoMode Player;


        void Start()
        {
            var playerButton = gameObject.GetComponentInParent<Button>();
            ChangeColor(playerButton);

            
        }
        public void GetButtonPress(Button button)
        {
            

            if (Player.AutoModeState)
            {
                Player.AutoModeState = false;
                ChangeColor(button);
            }
            else
            {
                Player.AutoModeState = true;
                ChangeColor(button);
            }
        }

        public void ChangeColor(Button button)
        {

            if (Player.AutoModeState)
            {
                ColorBlock colors = new ColorBlock();
                colors.normalColor = Color.cyan;
                colors.highlightedColor = Color.cyan;
                colors.pressedColor = Color.cyan;
                colors.selectedColor = Color.cyan;
                colors.disabledColor = Color.cyan;
                colors.colorMultiplier = 1;
                button.colors = colors;


            }
            else
            {
                ColorBlock colors = new ColorBlock();
                colors.normalColor = Color.white;
                colors.highlightedColor = Color.white;
                colors.pressedColor = Color.white;
                colors.selectedColor = Color.white;
                colors.disabledColor = Color.white;
                colors.colorMultiplier = 1;
                button.colors = colors;

            }
        }

    }
}

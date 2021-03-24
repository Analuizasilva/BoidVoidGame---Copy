using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.AutoMode.PeriodAM
{
    public class PeriodButtonManager : MonoBehaviour
    {
        public PeriodAutoMode Period;


        void Start()
        {
            var periodButton = gameObject.GetComponentInParent<Button>();
            ChangeColor(periodButton);


        }
        public void GetButtonPress(Button button)
        {


            if (Period.AutoModeState)
            {
                Period.AutoModeState = false;
                ChangeColor(button);
            }
            else
            {
                Period.AutoModeState = true;
                ChangeColor(button);
            }
        }

        public void ChangeColor(Button button)
        {

            if (Period.AutoModeState)
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

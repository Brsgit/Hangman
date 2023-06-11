using UnityEngine;

namespace Buttons
{
    public class ButtonFactory : IFactory<ButtonModel>
    {
        public ButtonModel Create(params object[] parameters)
        {
            var button = new ButtonModel((ButtonType)parameters[0], (string)parameters[1]);
            return button;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace AharHighLevel.Common
{
    public class CustomNotification : Confirmation, ICustomNotification
    {
        public MessageBoxTypes Type { get; set; }
        public int Buttons { get; set; }

        public MessageBoxButtons Result { get; set; }

        public CustomNotification(MessageBoxTypes _type, int _buttons)
        {
            Type = _type;
            Buttons = _buttons;
            Result = MessageBoxButtons.Cancel;
        }
        public CustomNotification()
        {
            Type = MessageBoxTypes.None;
            Buttons = 0;
            Result = MessageBoxButtons.Cancel;
        }
    }
}

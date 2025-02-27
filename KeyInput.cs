using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG_OOMS_Shawn_Bernard
{
    internal class KeyInput: Component
    {
        public enum keyState
        {
            Pressed,
            Held,
            Released,
            Up
        };

        bool currentState;
        bool lastState;

        private Keys trackedKey;

        public KeyInput(Keys trackedKey)
        {
            //Storing my throw in tracked key into this classes tracked key
            this.trackedKey = trackedKey;
        }

        public void UpdateKey(KeyboardState keyInput)
        {
            // Storing last key input bool into the last state
            // So if no key is pressed that would be false else true
            lastState = currentState;

            // Storing current state in the last state, which would store true or false when the key is pressed
            currentState = keyInput.IsKeyDown(trackedKey);
            
        }
        /// <summary>
        /// Since our bools are being updated every frame we need to find out if there being held, pressed, released or up
        /// </summary>
        /// <returns></returns>
        public keyState GetKeyState()
        {
            keyState ReturnState;
            // If my current state & last state = true
            // this happens because the states (bool) change every frame
            if (currentState && lastState)
            {
                ReturnState = keyState.Held;
            }
            // If the current state is true & last state is false
            // That would mean that the key was pressed
            else if (currentState && !lastState)
            {
                ReturnState = keyState.Pressed;
            }
            // If my current state is false & last state is true
            // that would mean the button is released
            else if (!currentState && lastState)
            {
                ReturnState = keyState.Released;
            }
            else// If all bool states are false that means the keys would be up
            {
                ReturnState = keyState.Up;
            }

            return ReturnState;
        }
    }
}

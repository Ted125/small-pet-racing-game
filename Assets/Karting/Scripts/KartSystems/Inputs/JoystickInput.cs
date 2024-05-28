using UnityEngine;

namespace KartGame.KartSystems {

    public class JoystickInput: BaseInput
    {
        public Joystick JoystickObject;

        public override InputData GenerateInput() {
            return new InputData
            {
                Accelerate = JoystickObject.Vertical >= 0.1f,
                Brake = JoystickObject.Vertical <= -0.1f,
                TurnInput = JoystickObject.Horizontal
            };
        }
    }
}

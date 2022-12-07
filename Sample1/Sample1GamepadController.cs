using UnityEngine;
using UnityEngine.InputSystem;

namespace KuriTaro.MultiController.Sample1 {
    public class Sample1GamepadController : Sample1BaseController {
        public override bool Action1() {
            return Gamepad.current.aButton.isPressed;
        }
        public override bool Action2() {
            return Gamepad.current.bButton.isPressed;
        }
        public override bool Accept() {
            return Action1();
        }
        public override bool Cancel() {
            return Action2();
        }
        public override Vector2 Stick() {
            return Gamepad.current.leftStick.ReadValue();
        }
        public override bool GetConnected() {
            return Gamepad.current != null;
        }
        public override bool GetInputAny() {
            var pad = Gamepad.current;
            return pad.aButton.wasPressedThisFrame
                || pad.bButton.wasPressedThisFrame
                || pad.xButton.wasPressedThisFrame
                || pad.yButton.wasPressedThisFrame;
        }
    }
}
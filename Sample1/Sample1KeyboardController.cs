using UnityEngine;
using UnityEngine.InputSystem;

namespace KuriTaro.MultiController.Sample1 {
    public class Sample1KeyboardController : Sample1BaseController {
        public override bool Action1() {
            return Keyboard.current.aKey.isPressed;
        }
        public override bool Action2() {
            return Keyboard.current.bKey.isPressed;
        }
        public override bool Accept() {
            return Action1();
        }
        public override bool Cancel() {
            return Action2();
        }
        public override Vector2 Stick() {
            Vector2 stick = Vector2.zero;
            stick.x = Keyboard.current.rightArrowKey.ReadValue() - Keyboard.current.leftArrowKey.ReadValue();
            stick.y = Keyboard.current.upArrowKey.ReadValue() - Keyboard.current.downArrowKey.ReadValue();
            return stick;
        }
        public override bool GetConnected() {
            return Keyboard.current != null;
        }
        public override bool GetInputAny() {
            return Keyboard.current.anyKey.wasPressedThisFrame;
        }
    }
}
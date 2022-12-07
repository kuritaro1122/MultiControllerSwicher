using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuriTaro.MultiController {
    public abstract class BaseController : MonoBehaviour, IBaseController {
        public abstract bool GetInputAny();
        public abstract bool GetConnected();
    }
    public enum ControllerType { Keyboard, Gamepad, Virtualpad }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KuriTaro.MultiController {
    public interface IBaseController {
        bool GetInputAny();
        bool GetConnected();
    }
}
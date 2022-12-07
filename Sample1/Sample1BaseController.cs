using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KuriTaro.MultiController;

namespace KuriTaro.MultiController.Sample1 {
    public abstract class Sample1BaseController : BaseController {
        public abstract bool Action1();
        public abstract bool Action2();
        public abstract Vector2 Stick();
        public abstract bool Accept();
        public abstract bool Cancel();
    }
}
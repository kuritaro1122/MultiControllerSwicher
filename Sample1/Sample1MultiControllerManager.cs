using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KuriTaro.MultiController;
using UnityEditor;

//public enum ControllerType { }

namespace KuriTaro.MultiController.Sample1 {
    public class Sample1MultiControllerManager : BaseMultiControllerManager<ControllerType, Sample1BaseController> {
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Sample1MultiControllerManager))]
    public class Sample1MultiControllerManagerEditor : BaseEntityStatusKeyControllerEditor<Sample1MultiControllerManager, ControllerType, Sample1BaseController> {
    }
#endif
}
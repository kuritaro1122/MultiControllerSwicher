using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace KuriTaro.MultiController {
    public abstract class BaseMultiControllerManager<E, T> : MonoBehaviour, IMultiControllerManager<E, T>
        where E : Enum
        where T : class, IBaseController
        {
        [SerializeField] List<T> controllers = new List<T>();
        private int controllerIndex = 0;

        public Type GetControllerType() => typeof(E);
        public List<T> GetControllers() => this.controllers;

        public int GetCurrentControllerIndex() => this.controllerIndex;
        public Enum GetCurrentControllerType() => (E)Enum.ToObject(typeof(E), GetCurrentControllerIndex());
        public T GetCurrentController() => this.controllers[GetCurrentControllerIndex()];

        protected virtual void Start() {

        }
        protected virtual void Update() {
            UpdateControllerIndex();
            //EditorApplication.QueuePlayerLoopUpdate();
        }

        private void UpdateControllerIndex() {
            for (int i = 0; i < this.controllers.Count; i++) {
                T _controller = this.controllers[i];
                if (_controller == null) {
                    continue;
                }
                if (_controller.GetConnected()) {
                    if (_controller.GetInputAny()) {
                        this.controllerIndex = i;
                        Debug.Log($"changeController: {this.controllerIndex}{_controller}");
                        break;
                    }
                } else continue;
            }
        }
    }

    public interface IMultiControllerManager<E, T> where E : Enum where T : IBaseController {
        Type GetControllerType();
        List<T> GetControllers();
        int GetCurrentControllerIndex();
        Enum GetCurrentControllerType();
        T GetCurrentController();
    }

#if UNITY_EDITOR
    //[CustomEditor(typeof(BaseMultiControllerManager<E, T>))]
    public abstract class BaseEntityStatusKeyControllerEditor<M, E, T> : Editor
        where M : class, IMultiControllerManager<E, T>
        where E : Enum
        where T : MonoBehaviour, IBaseController
        {
        public override void OnInspectorGUI() {
            //base.OnInspectorGUI();
            var _target = target as M;
            var enumNames = _target.GetControllerType().GetEnumNames();
            var controllers = _target.GetControllers();
            for (int i = 0; i < enumNames.Length; i++) {
                EditorGUILayout.LabelField(enumNames[i]);
                if (controllers.Count > i) {
                    var obj = EditorGUILayout.ObjectField(controllers[i], typeof(IBaseController), allowSceneObjects: true);
                    controllers[i] = obj as T;
                } else controllers.Add(null);
            }
            EditorGUILayout.Space(8);
            //EditorGUI.BeginDisabledGroup(true);
            //EditorGUILayout.EnumPopup("Current Controller", _target.GetCurrentControllerType());
            //EditorGUI.EndDisabledGroup();
        }
    }
#endif
}
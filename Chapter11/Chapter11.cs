using System;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using Fusee.Engine.GUI;
using System.Collections.Generic;
using System.Linq;

namespace FuseeApp
{
    [FuseeApplication(Name = "Chapter11", Description = "Yet another FUSEE App.")]
    public class Chapter11 : RenderCanvas
    {
        // Horizontal and vertical rotation Angles for the displayed object 
        private static float _angleHorz = M.PiOver4, _angleVert;

        // Horizontal and vertical angular speed
        private static float _angleVelHorz, _angleVelVert;

        // Overall speed factor. Change this to adjust how fast the rotation reacts to input
        private const float RotationSpeed = 7;

        // Damping factor 
        private const float Damping = 0.8f;

        private SceneContainer _houseScene;
        private SceneRendererForward _sceneRenderer;

        private TransformComponent dachTransform;

        private TransformComponent[] leftWheelTransforms = new TransformComponent[3];
        private TransformComponent[] rightWheelTransforms = new TransformComponent[3];

        private TransformComponent[] armTransforms = new TransformComponent[2];

        private bool _keys;

        private ScenePicker _scenePicker;

        private PickResult _currentPick;
        private float4 _oldColor;

        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(1, 1, 1, 1);

            // Load the rocket model
            _houseScene = AssetStorage.Get<SceneContainer>("rover.fus");

            //Get transform components
            for (int i = 0; i < 3; i++)
            {
                leftWheelTransforms[i] = _houseScene.Children.FindNodes(node => node.Name == "Rad_L_0" + (i + 1))?.FirstOrDefault()?.GetTransform();
            }
            for (int i = 0; i < 3; i++)
            {
                rightWheelTransforms[i] = _houseScene.Children.FindNodes(node => node.Name == "Rad_R_0" + (i + 1))?.FirstOrDefault()?.GetTransform();
            }
            for (int i = 0; i < 2; i++)
            {
                armTransforms[i] = _houseScene.Children.FindNodes(node => node.Name == "Arm_0" + (i + 1))?.FirstOrDefault()?.GetTransform();
            }

            // Wrap a SceneRenderer around the model.
            _sceneRenderer = new SceneRendererForward(_houseScene);

            _scenePicker = new ScenePicker(_houseScene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            if (Mouse.LeftButton)
            {
                float2 pickPosClip = Mouse.Position * new float2(2.0f / Width, -2.0f / Height) + new float2(-1, 1);
                _scenePicker.View = RC.View;
                _scenePicker.Projection = RC.Projection;
                List<PickResult> pickResults = _scenePicker.Pick(pickPosClip).ToList();
                if (pickResults.Count > 0)
                {
                    PickResult newPick = null;
                    if (pickResults.Count > 0)
                    {
                        pickResults.Sort((a, b) => Math.Sign(a.ClipPos.z - b.ClipPos.z));
                        newPick = pickResults[0];
                    }
                    if (newPick?.Node != _currentPick?.Node)
                    {
                        if (_currentPick != null)
                        {
                            _currentPick.Node.GetComponent<ShaderEffectComponent>().Effect.SetEffectParam("DiffuseColor", _oldColor);
                        }
                        if (newPick != null)
                        {
                            var mat = newPick.Node.GetComponent<ShaderEffectComponent>().Effect;
                            _oldColor = (float4)mat.GetEffectParam("DiffuseColor");
                            mat.SetEffectParam("DiffuseColor", new float4(1, 0.4f, 0.4f, 1));
                        }
                        _currentPick = newPick;
                    }
                }
            }

            if (Mouse.LeftButton)
            {
                _keys = false;
                _angleVelHorz = -RotationSpeed * Mouse.XVel * DeltaTime * 0.0005f;
                _angleVelVert = -RotationSpeed * Mouse.YVel * DeltaTime * 0.0005f;
            }
            else
            {
                var curDamp = (float)System.Math.Exp(-Damping * DeltaTime);
                _angleVelHorz *= curDamp;
                _angleVelVert *= curDamp;
            }


            if (_currentPick != null)
            {
                _currentPick.Node.GetComponent<TransformComponent>().Rotation.x += 3 * Keyboard.LeftRightAxis * DeltaTime;
                _currentPick.Node.GetComponent<TransformComponent>().Rotation.z += 3 * Keyboard.UpDownAxis * DeltaTime;
            }


            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;

            // Create the camera matrix and set it as the current View transformation
            var mtxRot = float4x4.CreateRotationX(_angleVert) * float4x4.CreateRotationY(_angleHorz);
            var mtxCam = float4x4.LookAt(0, 0, -14, 0, 1.5f, 0, 0, 1, 0);
            RC.View = mtxCam * mtxRot;

            // Tick any animations and Render the scene loaded in Init()
            _sceneRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }
    }
}
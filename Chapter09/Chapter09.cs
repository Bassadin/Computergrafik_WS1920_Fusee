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
    [FuseeApplication(Name = "Tut09_HierarchyAndInput", Description = "Yet another FUSEE App.")]
    public class Tut09_HierarchyAndInput : RenderCanvas
    {
        private SceneContainer scene;
        private SceneRendererForward sceneRenderer;
        private float _camAngle = 0;
        private TransformComponent baseTransform;
        private TransformComponent bodyTransform;

        //Arms
        private TransformComponent upperArmTransform;
        private TransformComponent lowerArmTransform;

        //Grabbers
        private TransformComponent grabber1Transform;
        private TransformComponent grabber2Transform;

        private enum GrabberState : int { open = 0, closing = 1, closed = 2, opening = 3 };
        private GrabberState currentGrabberState = GrabberState.open;

        //Once the grabber color
        private float3 grabberColor = new float3(0.2f, 0.2f, 0.2f);
        private float3 grabberCuboidSize = new float3(3, 8, 3);


        SceneContainer CreateScene()
        {
            // Initialize transform components that need to be changed inside "RenderAFrame"
            baseTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, -6, 0)
            };

            bodyTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 6, 0)
            };
            //Arms
            upperArmTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(2, 4, 0)
            };
            lowerArmTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(-2, 4, 0)
            };

            //Grabbers
            grabber1Transform = new TransformComponent
            {
                Rotation = new float3(-1, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 4, 0)
            };
            grabber2Transform = new TransformComponent
            {
                Rotation = new float3(1, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 4, 0)
            };

            // Setup the scene graph
            return new SceneContainer
            {
                Children = new List<SceneNodeContainer>
                {
                    new SceneNodeContainer
                    {
                        Name = "Base",
                        Components = new List<SceneComponentContainer>
                        {
                            // TRANSFROM COMPONENT
                            baseTransform,

                            // SHADER EFFECT COMPONENT
                            new ShaderEffectComponent
                            {
                                Effect = SimpleMeshes.MakeShaderEffect(new float3(0.7f, 0.7f, 0.7f), new float3(0.7f, 0.7f, 0.7f), 5)
                            },

                            // MESH COMPONENT
                            SimpleMeshes.CreateCuboid(new float3(10, 2, 10))
                        },
                        Children = new ChildList
                        {
                            new SceneNodeContainer
                            {
                                Name = "Body",
                                Components = new List<SceneComponentContainer>
                                {
                                    // TRANSFROM COMPONENT
                                    bodyTransform,

                                    // SHADER EFFECT COMPONENT
                                    new ShaderEffectComponent
                                    {
                                        Effect = SimpleMeshes.MakeShaderEffect(new float3(1, 0, 0), new float3(0.7f, 0.7f, 0.7f), 5)
                                    },

                                    // MESH COMPONENT
                                    SimpleMeshes.CreateCuboid(new float3(2, 10, 2))

                                },
                                Children = new ChildList
                                {
                                    new SceneNodeContainer
                                    {
                                        Name = "UpperArm",
                                        Components = new List<SceneComponentContainer>
                                        {
                                            upperArmTransform

                                        },
                                        Children = new ChildList
                                        {
                                            new SceneNodeContainer
                                            {
                                                Components = new List<SceneComponentContainer>
                                                {
                                                    new TransformComponent
                                                    {
                                                        Rotation = new float3(0, 0, 0),
                                                        Scale = new float3(1, 1, 1),
                                                        Translation = new float3(0, 4, 0)
                                                    },
                                                    new ShaderEffectComponent
                                                    {
                                                        Effect = SimpleMeshes.MakeShaderEffect(new float3(0, 1, 0), new float3(0.7f, 0.7f, 0.7f), 5)
                                                    },
                                                    SimpleMeshes.CreateCuboid(new float3(2, 10, 2))
                                                },
                                                Children = new ChildList {
                                                    new SceneNodeContainer
                                                    {
                                                        Name = "LowerArm",
                                                        Components = new List<SceneComponentContainer>
                                                        {
                                                            lowerArmTransform

                                                        },
                                                        Children = new ChildList
                                                        {
                                                            new SceneNodeContainer
                                                            {
                                                                Components = new List<SceneComponentContainer>
                                                                {
                                                                    new TransformComponent
                                                                    {
                                                                        Rotation = new float3(0, 0, 0),
                                                                        Scale = new float3(1, 1, 1),
                                                                        Translation = new float3(0, 4, 0)
                                                                    },
                                                                    new ShaderEffectComponent
                                                                    {
                                                                        Effect = SimpleMeshes.MakeShaderEffect(new float3(0, 0, 1), new float3(0.7f, 0.7f, 0.7f), 5)
                                                                    },
                                                                    SimpleMeshes.CreateCuboid(new float3(2, 10, 2))
                                                                },
                                                                Children = new ChildList
                                                                {
                                                                    new SceneNodeContainer
                                                                        {
                                                                            Name = "Grabber1",
                                                                            Components = new List<SceneComponentContainer>
                                                                            {
                                                                                grabber1Transform

                                                                            },
                                                                            Children = new ChildList
                                                                            {
                                                                                new SceneNodeContainer
                                                                                {
                                                                                    Components = new List<SceneComponentContainer>
                                                                                    {
                                                                                        new TransformComponent
                                                                                        {
                                                                                            Rotation = new float3(0, 0, 0),
                                                                                            Scale = new float3(1, 1, 1),
                                                                                            Translation = new float3(0, 4, 0)
                                                                                        },
                                                                                        new ShaderEffectComponent
                                                                                        {
                                                                                            Effect = SimpleMeshes.MakeShaderEffect(grabberColor, new float3(0.7f, 0.7f, 0.7f), 5)
                                                                                        },
                                                                                        SimpleMeshes.CreateCuboid(grabberCuboidSize)
                                                                                    }
                                                                                }
                                                                            }
                                                                        },
                                                                    new SceneNodeContainer
                                                                        {
                                                                            Name = "Grabber2",
                                                                            Components = new List<SceneComponentContainer>
                                                                            {
                                                                                grabber2Transform

                                                                            },
                                                                            Children = new ChildList
                                                                            {
                                                                                new SceneNodeContainer
                                                                                {
                                                                                    Components = new List<SceneComponentContainer>
                                                                                    {
                                                                                        new TransformComponent
                                                                                        {
                                                                                            Rotation = new float3(0, 0, 0),
                                                                                            Scale = new float3(1, 1, 1),
                                                                                            Translation = new float3(0, 4, 0)
                                                                                        },
                                                                                        new ShaderEffectComponent
                                                                                        {
                                                                                            Effect = SimpleMeshes.MakeShaderEffect(grabberColor, new float3(0.7f, 0.7f, 0.7f), 5)
                                                                                        },
                                                                                        SimpleMeshes.CreateCuboid(grabberCuboidSize)
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }


        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intensity in all color channels R, G, B, A).
            RC.ClearColor = new float4(0.8f, 0.9f, 0.7f, 1);

            scene = CreateScene();

            // Create a scene renderer holding the scene above
            sceneRenderer = new SceneRendererForward(scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            SetProjectionAndViewport();

            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            //Rotate robot axes
            upperArmTransform.Rotation.x += 1.5f * DeltaTime * Keyboard.UpDownAxis;
            lowerArmTransform.Rotation.x += 1.5f * DeltaTime * Keyboard.WSAxis;

            //Rotate camera with mouse
            if (Mouse.LeftButton)
            {
                _camAngle += -.01f * DeltaTime * Mouse.Velocity.x;
            }

            //Diagnostics.Debug(currentGrabberState);

            //Grabber movement
            if (Keyboard.IsKeyDown(KeyCodes.Space))
            {
                currentGrabberState = currentGrabberState == GrabberState.open || currentGrabberState == GrabberState.opening ? GrabberState.closing : GrabberState.opening;
                Diagnostics.Debug("Setting Grabber state to " + currentGrabberState);
            }

            if (currentGrabberState == GrabberState.closing)
            {
                grabber1Transform.Rotation.x += .5f * DeltaTime;
                grabber2Transform.Rotation.x -= .5f * DeltaTime;
                if (grabber1Transform.Rotation.x >= 0)
                {
                    Diagnostics.Debug("Setting Grabber state to closed");
                    currentGrabberState = GrabberState.closed;
                    grabber1Transform.Rotation.x = 0;
                    grabber2Transform.Rotation.x = 0;
                }
            } else if (currentGrabberState == GrabberState.opening) {
                grabber1Transform.Rotation.x -= .5f * DeltaTime;
                grabber2Transform.Rotation.x += .5f * DeltaTime;
                if (grabber1Transform.Rotation.x <= -1)
                {
                    Diagnostics.Debug("Setting Grabber state to open");
                    currentGrabberState = GrabberState.open;
                    grabber1Transform.Rotation.x = -1;
                    grabber2Transform.Rotation.x = 1;
                }
            }


            // Setup the camera 
            RC.View = float4x4.CreateTranslation(0, -10, 50) * float4x4.CreateRotationY(_camAngle);

            // Render the scene on the current render context
            sceneRenderer.Render(RC);

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered farame) on the front buffer.
            Present();
        }

        public void SetProjectionAndViewport()
        {
            // Set the rendering area to the entire window size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width / (float)Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }

    }
}
# Volumetric-Lighting
Adjustable volumetric lighting for URP in Unity
<br><br>

![Project Image](<./.gitimages/Volumetric Lighting 01.png>)
<br><br>

## Project Description
This is an example of applied volumetric lighting for URP in Unity based on [Christian Qiu's](https://github.com/CristianQiu/Unity-URP-Volumetric-Light) shaders and render graph support. His repo is highly recommended for compatibility and ease of use with full installation instructions available.
<br>

In this scene, volume strength from the point lights can be adjusted at runtime. Sets of traditional baked lightmaps are used with mixed lighting in Shadowmask mode, which are swapped out when enabling or disabling the different lights along with their respective baked emissive materials. Also, an Adaptive Probe Volume is applied for more accurate shadow blending.
<br>

Note: Some assets from the Unity Asset Store are required for a complete build. They are not included in this repo. Please see the Licenses section below for links to the assets. Otherwise, feel free to browse through the project files. Thanks.
<br><br>

## Player Controls
Move Player: WASD Keys -or- Arrows
<br>
Jump: Spacebar
<br><br>

## Project Features
* Adjustable volumetric lighting at runtime
* Main light, point light and spot light support
* Supports Adaptive Probe Volumes
* Compatible with Forward, Deferred, Forward+ and Deferred+ rendering paths
* Traditional lightmap swapping at runtime
* Mixed lighting using Shadowmask mode
* Emissive material swapping
* Adaptive Probe Volume for shadow blending
* Framerate counter
<br><br>

## Licenses
[MIT](./LICENSE)
<br>

[Volumetric Lighting Package](https://github.com/CristianQiu/Unity-URP-Volumetric-Light) by Christian Qiu: Required for the main scene. Available for purchase on the Unity Asset Store. Used under the standard Unity Asset Store EULA.
<br>

[Easy Character Movement 2](https://assetstore.unity.com/packages/tools/physics/easy-character-movement-2-193614) by Oscar Gracián: Required for the main scene. Available for purchase on the Unity Asset Store. Used under the standard Unity Asset Store EULA.
<br>

[Stylized Water 2](https://assetstore.unity.com/packages/vfx/shaders/stylized-water-2-170386) by Staggart Creations: Required for the main scene. Available for purchase on the Unity Asset Store. Used under the standard Unity Asset Store EULA.
<br>

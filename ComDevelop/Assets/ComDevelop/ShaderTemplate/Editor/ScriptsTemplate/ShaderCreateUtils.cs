using UnityEngine;
using UnityEditor;
using System.Collections;
 
/// <summary>
/// 通过方法"ScriptTemplateGenerator.GenerateShaderTemplete()"自动生成，不要修改该脚本内容
/// </summary>
public class ShaderCreateUtils
{


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Bumped Diffuse")]
    static void CreateShader0000()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-Bumped.shader.txt", "New Alpha-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Bumped Specular")]
    static void CreateShader0001()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-BumpSpec.shader.txt", "New Alpha-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Diffuse")]
    static void CreateShader0002()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-Diffuse.shader.txt", "New Alpha-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Specular")]
    static void CreateShader0003()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-Glossy.shader.txt", "New Alpha-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Parallax Diffuse")]
    static void CreateShader0004()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-Parallax.shader.txt", "New Alpha-Parallax.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Parallax Specular")]
    static void CreateShader0005()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-ParallaxSpec.shader.txt", "New Alpha-ParallaxSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/VertexLit")]
    static void CreateShader0006()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Alpha-VertexLit.shader.txt", "New Alpha-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/Bumped Diffuse")]
    static void CreateShader0007()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-Bumped.shader.txt", "New AlphaTest-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/Bumped Specular")]
    static void CreateShader0008()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-BumpSpec.shader.txt", "New AlphaTest-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/Diffuse")]
    static void CreateShader0009()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-Diffuse.shader.txt", "New AlphaTest-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/Specular")]
    static void CreateShader0010()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-Glossy.shader.txt", "New AlphaTest-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/Soft Edge Unlit")]
    static void CreateShader0011()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-SoftEdgeUnlit.shader.txt", "New AlphaTest-SoftEdgeUnlit.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Transparent/Cutout/VertexLit")]
    static void CreateShader0012()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\AlphaTest-VertexLit.shader.txt", "New AlphaTest-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Decal")]
    static void CreateShader0013()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Decal.shader.txt", "New Decal.shader");
    }


    [MenuItem("Assets/CreateShader/FX/Flare")]
    static void CreateShader0014()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Flare.shader.txt", "New Flare.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Bumped Diffuse")]
    static void CreateShader0015()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-Bumped.shader.txt", "New Illumin-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Bumped Specular")]
    static void CreateShader0016()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-BumpSpec.shader.txt", "New Illumin-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Diffuse")]
    static void CreateShader0017()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-Diffuse.shader.txt", "New Illumin-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Specular")]
    static void CreateShader0018()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-Glossy.shader.txt", "New Illumin-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Parallax Diffuse")]
    static void CreateShader0019()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-Parallax.shader.txt", "New Illumin-Parallax.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/Parallax Specular")]
    static void CreateShader0020()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-ParallaxSpec.shader.txt", "New Illumin-ParallaxSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Self-Illumin/VertexLit")]
    static void CreateShader0021()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Illumin-VertexLit.shader.txt", "New Illumin-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/BlitCopy")]
    static void CreateShader0022()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-BlitCopy.shader.txt", "New Internal-BlitCopy.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/BlitCopyDepth")]
    static void CreateShader0023()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-BlitCopyDepth.shader.txt", "New Internal-BlitCopyDepth.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-CombineDepthNormals")]
    static void CreateShader0024()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-CombineDepthNormals.shader.txt", "New Internal-CombineDepthNormals.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/ConvertTexture")]
    static void CreateShader0025()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-ConvertTexture.shader.txt", "New Internal-ConvertTexture.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-DeferredReflections")]
    static void CreateShader0026()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-DeferredReflections.shader.txt", "New Internal-DeferredReflections.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-DeferredShading")]
    static void CreateShader0027()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-DeferredShading.shader.txt", "New Internal-DeferredShading.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-DepthNormalsTexture")]
    static void CreateShader0028()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-DepthNormalsTexture.shader.txt", "New Internal-DepthNormalsTexture.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-Flare")]
    static void CreateShader0029()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-Flare.shader.txt", "New Internal-Flare.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-GUITexture")]
    static void CreateShader0030()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-GUITexture.shader.txt", "New Internal-GUITexture.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-GUITextureBlit")]
    static void CreateShader0031()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-GUITextureBlit.shader.txt", "New Internal-GUITextureBlit.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-GUITextureClip")]
    static void CreateShader0032()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-GUITextureClip.shader.txt", "New Internal-GUITextureClip.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-GUITextureClipText")]
    static void CreateShader0033()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-GUITextureClipText.shader.txt", "New Internal-GUITextureClipText.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-Halo")]
    static void CreateShader0034()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-Halo.shader.txt", "New Internal-Halo.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-MotionVectors")]
    static void CreateShader0035()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-MotionVectors.shader.txt", "New Internal-MotionVectors.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-PrePassLighting")]
    static void CreateShader0036()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-PrePassLighting.shader.txt", "New Internal-PrePassLighting.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-ScreenSpaceShadows")]
    static void CreateShader0037()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-ScreenSpaceShadows.shader.txt", "New Internal-ScreenSpaceShadows.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Internal-StencilWrite")]
    static void CreateShader0038()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Internal-StencilWrite.shader.txt", "New Internal-StencilWrite.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Lightmapped/Bumped Diffuse")]
    static void CreateShader0039()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Lightmap-Bumped.shader.txt", "New Lightmap-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Lightmapped/Bumped Specular")]
    static void CreateShader0040()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Lightmap-BumpSpec.shader.txt", "New Lightmap-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Lightmapped/Diffuse")]
    static void CreateShader0041()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Lightmap-Diffuse.shader.txt", "New Lightmap-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Lightmapped/Specular")]
    static void CreateShader0042()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Lightmap-Glossy.shader.txt", "New Lightmap-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Lightmapped/VertexLit")]
    static void CreateShader0043()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Lightmap-VertexLit.shader.txt", "New Lightmap-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Bumped Diffuse")]
    static void CreateShader0044()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-Bumped.shader.txt", "New Normal-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Bumped Specular")]
    static void CreateShader0045()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-BumpSpec.shader.txt", "New Normal-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Diffuse")]
    static void CreateShader0046()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-Diffuse.shader.txt", "New Normal-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Diffuse Detail")]
    static void CreateShader0047()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-DiffuseDetail.shader.txt", "New Normal-DiffuseDetail.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Diffuse Fast")]
    static void CreateShader0048()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-DiffuseFast.shader.txt", "New Normal-DiffuseFast.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Specular")]
    static void CreateShader0049()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-Glossy.shader.txt", "New Normal-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Parallax Diffuse")]
    static void CreateShader0050()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-Parallax.shader.txt", "New Normal-Parallax.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Parallax Specular")]
    static void CreateShader0051()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-ParallaxSpec.shader.txt", "New Normal-ParallaxSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/VertexLit")]
    static void CreateShader0052()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Normal-VertexLit.shader.txt", "New Normal-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Additive")]
    static void CreateShader0053()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Add.shader.txt", "New Particle Add.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/~Additive-Multiply")]
    static void CreateShader0054()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle AddMultiply.shader.txt", "New Particle AddMultiply.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Additive (Soft)")]
    static void CreateShader0055()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle AddSmooth.shader.txt", "New Particle AddSmooth.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Alpha Blended")]
    static void CreateShader0056()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Alpha Blend.shader.txt", "New Particle Alpha Blend.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Anim Alpha Blended")]
    static void CreateShader0057()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Anim Alpha Blend.shader.txt", "New Particle Anim Alpha Blend.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Blend")]
    static void CreateShader0058()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Blend.shader.txt", "New Particle Blend.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Multiply")]
    static void CreateShader0059()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Multiply.shader.txt", "New Particle Multiply.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Multiply (Double)")]
    static void CreateShader0060()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle MultiplyDouble.shader.txt", "New Particle MultiplyDouble.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/Alpha Blended Premultiply")]
    static void CreateShader0061()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle Premultiply Blend.shader.txt", "New Particle Premultiply Blend.shader");
    }


    [MenuItem("Assets/CreateShader/Particles/VertexLit Blended")]
    static void CreateShader0062()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Particle VertexLit Blended.shader.txt", "New Particle VertexLit Blended.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Bumped Diffuse")]
    static void CreateShader0063()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-Bumped.shader.txt", "New Reflect-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Bumped Unlit")]
    static void CreateShader0064()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-BumpNolight.shader.txt", "New Reflect-BumpNolight.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Bumped Specular")]
    static void CreateShader0065()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-BumpSpec.shader.txt", "New Reflect-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Bumped VertexLit")]
    static void CreateShader0066()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-BumpVertexLit.shader.txt", "New Reflect-BumpVertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Diffuse")]
    static void CreateShader0067()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-Diffuse.shader.txt", "New Reflect-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Specular")]
    static void CreateShader0068()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-Glossy.shader.txt", "New Reflect-Glossy.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Parallax Diffuse")]
    static void CreateShader0069()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-Parallax.shader.txt", "New Reflect-Parallax.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/Parallax Specular")]
    static void CreateShader0070()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-ParallaxSpec.shader.txt", "New Reflect-ParallaxSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Legacy Shaders/Reflective/VertexLit")]
    static void CreateShader0071()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Reflect-VertexLit.shader.txt", "New Reflect-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Skybox/Cubemap")]
    static void CreateShader0072()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Skybox-Cubed.shader.txt", "New Skybox-Cubed.shader");
    }


    [MenuItem("Assets/CreateShader/Skybox/Procedural")]
    static void CreateShader0073()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Skybox-Procedural.shader.txt", "New Skybox-Procedural.shader");
    }


    [MenuItem("Assets/CreateShader/Skybox/6 Sided")]
    static void CreateShader0074()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Skybox.shader.txt", "New Skybox.shader");
    }


    [MenuItem("Assets/CreateShader/Sprites/Default")]
    static void CreateShader0075()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Sprites-Default.shader.txt", "New Sprites-Default.shader");
    }


    [MenuItem("Assets/CreateShader/Sprites/Diffuse")]
    static void CreateShader0076()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Sprites-Diffuse.shader.txt", "New Sprites-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Standard")]
    static void CreateShader0077()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Standard.shader.txt", "New Standard.shader");
    }


    [MenuItem("Assets/CreateShader/Standard (Specular setup)")]
    static void CreateShader0078()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\StandardSpecular.shader.txt", "New StandardSpecular.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/VideoDecode")]
    static void CreateShader0079()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VideoDecode.shader.txt", "New VideoDecode.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/VideoDecodeAndroid")]
    static void CreateShader0080()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VideoDecodeAndroid.shader.txt", "New VideoDecodeAndroid.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/VideoDecodeOSX")]
    static void CreateShader0081()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VideoDecodeOSX.shader.txt", "New VideoDecodeOSX.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/CubeBlend")]
    static void CreateShader0082()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Cubemaps\CubeBlend.shader.txt", "New CubeBlend.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/CubeBlur")]
    static void CreateShader0083()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Cubemaps\CubeBlur.shader.txt", "New CubeBlur.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/CubeBlurOdd")]
    static void CreateShader0084()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Cubemaps\CubeBlurOdd.shader.txt", "New CubeBlurOdd.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/CubeCopy")]
    static void CreateShader0085()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Cubemaps\CubeCopy.shader.txt", "New CubeCopy.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/GIDebug/ShowLightMask")]
    static void CreateShader0086()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\GIDebug\ShowLightMask.shader.txt", "New ShowLightMask.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/GIDebug/TextureUV")]
    static void CreateShader0087()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\GIDebug\TextureUV.shader.txt", "New TextureUV.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/GIDebug/UV1sAsPositions")]
    static void CreateShader0088()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\GIDebug\UV1sAsPositions.shader.txt", "New UV1sAsPositions.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/GIDebug/VertexColors")]
    static void CreateShader0089()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\GIDebug\VertexColors.shader.txt", "New VertexColors.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Bumped Diffuse")]
    static void CreateShader0090()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Bumped.shader.txt", "New Mobile-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Bumped Specular (1 Directional Light)")]
    static void CreateShader0091()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-BumpSpec-1DirectionalLight.shader.txt", "New Mobile-BumpSpec-1DirectionalLight.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Bumped Specular")]
    static void CreateShader0092()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-BumpSpec.shader.txt", "New Mobile-BumpSpec.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Diffuse")]
    static void CreateShader0093()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Diffuse.shader.txt", "New Mobile-Diffuse.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Unlit (Supports Lightmap)")]
    static void CreateShader0094()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Lightmap-Unlit.shader.txt", "New Mobile-Lightmap-Unlit.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Particles/Additive")]
    static void CreateShader0095()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Particle-Add.shader.txt", "New Mobile-Particle-Add.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Particles/VertexLit Blended")]
    static void CreateShader0096()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Particle-Alpha-VertexLit.shader.txt", "New Mobile-Particle-Alpha-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Particles/Alpha Blended")]
    static void CreateShader0097()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Particle-Alpha.shader.txt", "New Mobile-Particle-Alpha.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Particles/Multiply")]
    static void CreateShader0098()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Particle-Multiply.shader.txt", "New Mobile-Particle-Multiply.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/Skybox")]
    static void CreateShader0099()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-Skybox.shader.txt", "New Mobile-Skybox.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/VertexLit (Only Directional Lights)")]
    static void CreateShader0100()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-VertexLit-OnlyDirectionalLights.shader.txt", "New Mobile-VertexLit-OnlyDirectionalLights.shader");
    }


    [MenuItem("Assets/CreateShader/Mobile/VertexLit")]
    static void CreateShader0101()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Mobile\Mobile-VertexLit.shader.txt", "New Mobile-VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/SpeedTree")]
    static void CreateShader0102()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SpeedTree.shader.txt", "New SpeedTree.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/SpeedTree Billboard")]
    static void CreateShader0103()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SpeedTreeBillboard.shader.txt", "New SpeedTreeBillboard.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Tree Soft Occlusion Bark")]
    static void CreateShader0104()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SoftOcclusion\TreeSoftOcclusionBark.shader.txt", "New TreeSoftOcclusionBark.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Soft Occlusion Bark Rendertex")]
    static void CreateShader0105()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SoftOcclusion\TreeSoftOcclusionBarkRendertex.shader.txt", "New TreeSoftOcclusionBarkRendertex.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Tree Soft Occlusion Leaves")]
    static void CreateShader0106()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SoftOcclusion\TreeSoftOcclusionLeaves.shader.txt", "New TreeSoftOcclusionLeaves.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Soft Occlusion Leaves Rendertex")]
    static void CreateShader0107()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\SoftOcclusion\TreeSoftOcclusionLeavesRendertex.shader.txt", "New TreeSoftOcclusionLeavesRendertex.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Tree Creator Bark")]
    static void CreateShader0108()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorBark.shader.txt", "New TreeCreatorBark.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Creator Bark Optimized")]
    static void CreateShader0109()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorBarkOptimized.shader.txt", "New TreeCreatorBarkOptimized.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Creator Bark Rendertex")]
    static void CreateShader0110()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorBarkRendertex.shader.txt", "New TreeCreatorBarkRendertex.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Tree Creator Leaves")]
    static void CreateShader0111()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorLeaves.shader.txt", "New TreeCreatorLeaves.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Tree Creator Leaves Fast")]
    static void CreateShader0112()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorLeavesFast.shader.txt", "New TreeCreatorLeavesFast.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Creator Leaves Fast Optimized")]
    static void CreateShader0113()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorLeavesFastOptimized.shader.txt", "New TreeCreatorLeavesFastOptimized.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Creator Leaves Optimized")]
    static void CreateShader0114()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorLeavesOptimized.shader.txt", "New TreeCreatorLeavesOptimized.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/Nature/Tree Creator Leaves Rendertex")]
    static void CreateShader0115()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Nature\TreeCreator\TreeCreatorLeavesRendertex.shader.txt", "New TreeCreatorLeavesRendertex.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Details/Vertexlit")]
    static void CreateShader0116()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Details\VertexLit.shader.txt", "New VertexLit.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Details/WavingDoublePass")]
    static void CreateShader0117()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Details\WavingGrass.shader.txt", "New WavingGrass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Details/BillboardWavingDoublePass")]
    static void CreateShader0118()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Details\WavingGrassBillboard.shader.txt", "New WavingGrassBillboard.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Splatmap/Diffuse-AddPass")]
    static void CreateShader0119()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\AddPass.shader.txt", "New AddPass.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Terrain/Diffuse")]
    static void CreateShader0120()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\FirstPass.shader.txt", "New FirstPass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Splatmap/Specular-AddPass")]
    static void CreateShader0121()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Specular-AddPass.shader.txt", "New Specular-AddPass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Splatmap/Specular-Base")]
    static void CreateShader0122()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Specular-Base.shader.txt", "New Specular-Base.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Terrain/Specular")]
    static void CreateShader0123()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Specular-FirstPass.shader.txt", "New Specular-FirstPass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Splatmap/Standard-AddPass")]
    static void CreateShader0124()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Standard-AddPass.shader.txt", "New Standard-AddPass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/Splatmap/Standard-Base")]
    static void CreateShader0125()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Standard-Base.shader.txt", "New Standard-Base.shader");
    }


    [MenuItem("Assets/CreateShader/Nature/Terrain/Standard")]
    static void CreateShader0126()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Splats\Standard-FirstPass.shader.txt", "New Standard-FirstPass.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/TerrainEngine/BillboardTree")]
    static void CreateShader0127()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\TerrainShaders\Trees\BillboardTree.shader.txt", "New BillboardTree.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Default")]
    static void CreateShader0128()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Default.shader.txt", "New UI-Default.shader");
    }


    [MenuItem("Assets/CreateShader/UI/DefaultETC1")]
    static void CreateShader0129()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-DefaultETC1.shader.txt", "New UI-DefaultETC1.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Default Font")]
    static void CreateShader0130()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-DefaultFont.shader.txt", "New UI-DefaultFont.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Lit/Bumped")]
    static void CreateShader0131()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Lit-Bumped.shader.txt", "New UI-Lit-Bumped.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Lit/Detail")]
    static void CreateShader0132()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Lit-Detail.shader.txt", "New UI-Lit-Detail.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Lit/Refraction")]
    static void CreateShader0133()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Lit-Refraction.shader.txt", "New UI-Lit-Refraction.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Lit/Refraction Detail")]
    static void CreateShader0134()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Lit-RefractionDetail.shader.txt", "New UI-Lit-RefractionDetail.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Lit/Transparent")]
    static void CreateShader0135()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Lit-Transparent.shader.txt", "New UI-Lit-Transparent.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Unlit/Detail")]
    static void CreateShader0136()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Unlit-Detail.shader.txt", "New UI-Unlit-Detail.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Unlit/Text")]
    static void CreateShader0137()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Unlit-Text.shader.txt", "New UI-Unlit-Text.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Unlit/Text Detail")]
    static void CreateShader0138()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Unlit-TextDetail.shader.txt", "New UI-Unlit-TextDetail.shader");
    }


    [MenuItem("Assets/CreateShader/UI/Unlit/Transparent")]
    static void CreateShader0139()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\UI\UI-Unlit-Transparent.shader.txt", "New UI-Unlit-Transparent.shader");
    }


    [MenuItem("Assets/CreateShader/Unlit/Transparent")]
    static void CreateShader0140()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Unlit\Unlit-Alpha.shader.txt", "New Unlit-Alpha.shader");
    }


    [MenuItem("Assets/CreateShader/Unlit/Transparent Cutout")]
    static void CreateShader0141()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Unlit\Unlit-AlphaTest.shader.txt", "New Unlit-AlphaTest.shader");
    }


    [MenuItem("Assets/CreateShader/Unlit/Color")]
    static void CreateShader0142()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Unlit\Unlit-Color.shader.txt", "New Unlit-Color.shader");
    }


    [MenuItem("Assets/CreateShader/Unlit/Texture")]
    static void CreateShader0143()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Unlit\Unlit-Normal.shader.txt", "New Unlit-Normal.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/VR/BlitCopyFromTexArray")]
    static void CreateShader0144()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VR\Shaders\BlitCopyFromTexArray.shader.txt", "New BlitCopyFromTexArray.shader");
    }


    [MenuItem("Assets/CreateShader/Hidden/VR/Internal-VRDistortion")]
    static void CreateShader0145()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VR\Shaders\Internal-VRDistortion.shader.txt", "New Internal-VRDistortion.shader");
    }


    [MenuItem("Assets/CreateShader/VR/SpatialMapping/Occlusion")]
    static void CreateShader0146()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VR\Shaders\SpatialMappingOcclusion.shader.txt", "New SpatialMappingOcclusion.shader");
    }


    [MenuItem("Assets/CreateShader/VR/SpatialMapping/Wireframe")]
    static void CreateShader0147()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\VR\Shaders\SpatialMappingWireframe.shader.txt", "New SpatialMappingWireframe.shader");
    }


    [MenuItem("Assets/CreateShader/Wind/Sample VF")]
    static void CreateShader0148()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Wind\Shaders\SampleVF.shader.txt", "NewSampleVF.shader");
    }

    [MenuItem("Assets/CreateShader/Wind/Sample Surface")]
    static void CreateShader0149()
    {
        ProjectWindowUtilEx.CreateScriptUtil(@"Assets\ComDevelop\ShaderTemplate\Templates\Shaders\Wind\Shaders\SampleSurface.shader.txt", "NewSampleSurface.shader");
    }

}

#if UNITY_EDITOR && !EDXR_VIEWER
namespace Caffeine.Editor.Management.Processes
{
    using System.Collections.Generic;
    using Build.Protocol;
    using UnityEditor.Build;
    using UnityEditor.Rendering;
    using UnityEngine;

    // Shader compilation visibility (Builder V3.5, Plan C — Phase 1a).
    //
    // Unity invokes IPreprocessShaders.OnProcessShader once per shader
    // pass/stage, on the main thread, immediately before that pass is handed
    // to the shader compiler pool — in both Player and AssetBundle builds. It
    // is the only in-process signal that exists during BuildAssetBundles; the
    // payload is otherwise silent from "Creating Streaming Asset Bundle"
    // until the bundle is on disk, which on a cold ShaderCache can be hours.
    //
    // This reporter strips nothing. It runs LAST in callback order so that
    // `data.Count` is the count after every other stripper (URP's included)
    // has run — i.e. the number Unity prints as "After scriptable stripping"
    // and the real unit of compile work. Each call becomes one "shader" line
    // on the builder status channel; the supervisor aggregates them and the
    // parent renders "Compiling shaders — N shaders · M variants · …" under
    // the Building step. BuildProcess closes the sub-state with
    // EmitShaderComplete() when BuildAssetBundles returns.
    //
    // Display only. Nothing here may throw into the build pipeline, and
    // StatusWriter already swallows IO failures; the try/catch below is
    // belt-and-braces against a null snippet or a disposed shader.
    //
    // This assembly only compiles inside builder Unity projects, so the
    // callback never fires in an authoring editor; StatusWriter additionally
    // no-ops outside batch mode.
    public sealed class ShaderCompileReporter : IPreprocessShaders
    {
        public int callbackOrder => int.MaxValue;

        public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
        {
            try
            {
                StatusWriter.EmitShaderPass(
                    shader != null ? shader.name : string.Empty,
                    snippet.passName,
                    StageToken(snippet.shaderType),
                    data?.Count ?? 0);
            }
            catch
            {
                // Never let reporting touch the build.
            }
        }

        // Match the suffix Unity prints in its own log ("Compiling shader …
        // (vp)") so a status line and a log line for the same pass read alike.
        private static string StageToken(ShaderType type)
        {
            switch (type)
            {
                case ShaderType.Vertex: return "vp";
                case ShaderType.Fragment: return "fp";
                case ShaderType.Geometry: return "gp";
                case ShaderType.Hull: return "hp";
                case ShaderType.Domain: return "dp";
                default: return type.ToString().ToLowerInvariant();
            }
        }
    }
}
#endif

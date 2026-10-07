#if UNITY_EDITOR
namespace Caffeine.Editor.Build
{
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    // This assembly only ever compiles inside builder Unity projects (the
    // parent hides BuilderPayload~ from its own import and junctions it into
    // Builders/<Platform>/Packages as com.caffeine.builder). The builder role
    // itself is the Meta.json marker at the project root (BuilderRole); the
    // parent writes it when it creates a builder and re-checks it every
    // session. This is the in-builder backstop for a builder whose marker
    // went missing or was overwritten: rewrite it from here. Plain file
    // write — no recompile or domain reload, unlike the scripting define this
    // replaced.
    //
    // BuilderRole.EnsureBuilderMarker only writes when this project really is
    // <parent>/Builders/<Platform>, so even if this package were wrongly
    // installed in an authoring project it could not mark it as a builder.
    // BuilderRole.IsBuilder needs no help meanwhile: it already treats a
    // marker-less project in a parent's Builders folder as a builder.
    public static class BuilderRoleAssert
    {
        [InitializeOnLoadMethod]
        private static void EnsureBuilderMarker()
        {
            var projectRoot = Directory.GetCurrentDirectory();
            if (BuilderRole.ReadMarker(projectRoot) is { IsParent: false }) return;

            if (BuilderRole.EnsureBuilderMarker(projectRoot))
            {
                Debug.Log($"[Caffeine Builder] Restored the missing builder marker ({BuilderRole.MarkerFileName}).");
            }
        }
    }
}
#endif

/* Distributed under the Apache License, Version 2.0.
   See accompanying NOTICE file for details.*/

using System.Runtime.InteropServices;
using UnityEngine;

using Pulse;

namespace Pulse.Unity
{
  // This is essentially a copy of the PulseScenarioExec class from our engine repository
  // We have to do this to support the different Attribute values for iOS and all other platforms
  // This will need to stay in sync with the PulseScenarioExec class in the engine repository
  // But I do not see that class changing very often....

  [ExecuteInEditMode]
  public class PulseUnityScenarioExec : PulseScenarioExecBase
  {
#if UNITY_IOS
    private const string Attribute = "__Internal";
#else
    private const string Attribute = "PulseC";
#endif

    public PulseUnityScenarioExec() : base() { }

#if UNITY_WEBGL && !UNITY_EDITOR
    // EdXR courses don't run Pulse scenario files (they load patient states and
    // apply action nodes), so the native ExecuteScenario entrypoint is skipped on
    // the WebGL player. This keeps PulseScenarioExec.cpp.o — and its libc++
    // exception_ptr symbols (__cxa_init_primary_exception,
    // exception_ptr::__from_native_exception_pointer), which Unity's emscripten
    // 3.1.39 libc++ doesn't export — out of the wasm link.
    protected override bool BaseExecuteScenario(string exeOpts, int format) => false;
#else
    [DllImport(Attribute)]
    private static extern bool ExecuteScenario(string exeOpts, int format);
    protected override bool BaseExecuteScenario(string exeOpts, int format)
    {
      return ExecuteScenario(exeOpts, format);
    }
#endif
  }
}
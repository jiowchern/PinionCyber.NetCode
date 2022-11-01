using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using UnityEditor.Compilation;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace PinionCyber.NetCode
{
    class ScriptPostprocessor : AssetPostprocessor
    {
        protected void OnPreprocessAsset()
        {
           
        }
    }
    public static class Startup
    {
        [RuntimeInitializeOnLoadMethod]
        static void Startup1()
        {

            Debug.Log("123");
            CompilationPipeline.compilationStarted += (o) => {
                var all = CompilationPipeline.GetAssemblies(AssembliesType.Editor).Concat(CompilationPipeline.GetAssemblies(AssembliesType.Player));
                foreach (var asm in all)
                {
                    var args = new System.Collections.Generic.List<string>(asm.compilerOptions.AdditionalCompilerArguments);
                    args.Add(@"/additionalfile:E:\develop\PinionCyber.NetCode\PinionCyber.NetCode\Assets\PinionCyber.NetCode\regulus.remote.configuration.toml");
                    asm.compilerOptions.AdditionalCompilerArguments = args.ToArray();
                };
            };


        }
    }

}

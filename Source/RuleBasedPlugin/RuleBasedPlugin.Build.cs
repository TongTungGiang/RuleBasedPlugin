// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.
using System.IO;
using System;
using UnrealBuildTool;

namespace UnrealBuildTool.Rules
{
	public class RuleBasedPlugin : ModuleRules
	{
		public RuleBasedPlugin(TargetInfo Target)
		{
			PublicIncludePaths.AddRange(
				new string[] {
					// ... add public include paths required here ...
					Path.GetFullPath(Path.Combine(ModulePath, "Public")),
				}
				);

			PrivateIncludePaths.AddRange(
				new string[] {
					//"Developer/BlankPlugin/Private",
					// ... add other private include paths required here ...
					Path.GetFullPath(Path.Combine(ThirdPartyPath, "CLIPS/Source")),
					Path.GetFullPath(Path.Combine(ModulePath, "Private")),
				}
				);

			PublicDependencyModuleNames.AddRange(
				new string[]
				{
					"Core",
					"Engine"
					// ... add other public dependencies that you statically link with here ...
				}
				);

			PrivateDependencyModuleNames.AddRange(
				new string[]
				{
					// ... add private dependencies that you statically link with here ...
				}
				);

			DynamicallyLoadedModuleNames.AddRange(
				new string[]
				{
					// ... add any modules that your module loads dynamically here ...
				}
				);

			//LoadCLIPS(Target);

			//if (Target.Platform == UnrealTargetPlatform.Win64)
			//{
			//	string LibPath = Path.GetFullPath(
			//			Path.Combine(ThirdPartyPath, "CLIPS", "LIbraries")
			//		);
			//	PublicLibraryPaths.Add(LibPath);

			//	Console.WriteLine("... LibrariesPath -> " + LibPath);

			//	PublicAdditionalLibraries.Add(Path.Combine(LibPath, "CLIPSStatic64.lib"));
			//	PublicAdditionalLibraries.Add(Path.Combine(LibPath, "CLIPSDynamic64.lib"));
			//	PublicAdditionalLibraries.Add(Path.Combine(LibPath, "CLIPSWrapper64.lib"));
			//}
		}
		
		public bool LoadCLIPS(TargetInfo Target)
		{
			bool isLibrarySupported = false;

			if ((Target.Platform == UnrealTargetPlatform.Win64) || (Target.Platform == UnrealTargetPlatform.Win32))
			{
				isLibrarySupported = true;

				string LibrariesPath = Path.Combine(ThirdPartyPath, "CLIPS", "Libraries");

				Console.WriteLine("... ThirdPartyPath -> " + ThirdPartyPath);
				Console.WriteLine("... LibrariesPath -> " + LibrariesPath);

				PublicLibraryPaths.Add(LibrariesPath);

				//PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "CLIPSStatic64.lib"));
				//PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "CLIPSDynamic64.lib"));
				//PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "CLIPSWrapper64.lib"));

				PublicAdditionalLibraries.Add("CLIPSStatic64.lib");
				PublicAdditionalLibraries.Add("CLIPSDynamic64.lib");
				PublicAdditionalLibraries.Add("CLIPSWrapper64.lib");
			}

			if (isLibrarySupported)
			{
				// Include path
				PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "RuleBasedPlugin", "Include"));
			}

			Definitions.Add(string.Format("WITH_CLIPS_BINDING={0}", isLibrarySupported ? 1 : 0));

			return isLibrarySupported;
		}

		private string ModulePath
		{
			get { return ModuleDirectory; }
		}

		private string ThirdPartyPath
		{
			get { return Path.GetFullPath(Path.Combine(ModulePath, "../../ThirdParty/")); }
		}
	}
}
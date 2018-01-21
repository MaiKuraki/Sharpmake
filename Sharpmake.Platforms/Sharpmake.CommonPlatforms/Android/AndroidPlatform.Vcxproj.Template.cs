﻿// Copyright (c) 2017 Ubisoft Entertainment
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace Sharpmake
{
    public static partial class Android
    {
        public sealed partial class AndroidPlatform
        {
            private const string _projectDescriptionPlatformSpecific =
@"    <ApplicationType>Android</ApplicationType>
    <ApplicationTypeRevision>[applicationTypeRevision]</ApplicationTypeRevision>
";

            private const string _projectConfigurationsGeneralTemplate =
@"  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='[conf.Name]|[platformName]'"" Label=""Configuration"">
    <ConfigurationType>[options.ConfigurationType]</ConfigurationType>
    <UseDebugLibraries>[options.UseDebugLibraries]</UseDebugLibraries>
    <PlatformToolset>[options.PlatformToolset]</PlatformToolset>
    <UseOfStl>[options.UseOfStl]</UseOfStl>
    <ThumbMode>[options.ThumbMode]</ThumbMode>
    <AndroidAPILevel>[options.AndroidAPILevel]</AndroidAPILevel>
  </PropertyGroup>
";

            // The output directory is converted to a rooted path by prefixing it with $(ProjectDir) to work around
            // an issue with VS Android build scripts. When a project dependency has its project folder not at the
            // same folder level as the AndroidPackageProject, VS can't locate its output properly using its relative path.
            private const string _projectConfigurationsGeneral2Template =
@"  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='[conf.Name]|[platformName]'"">
    <TargetName>[options.OutputFileName]</TargetName>
    <OutDir>$(ProjectDir)[options.OutputDirectory]\</OutDir>
    <IntDir>[options.IntermediateDirectory]\</IntDir>
    <TargetExt>[options.OutputFileExtension]</TargetExt>
    <PostBuildEventUseInBuild>[options.PostBuildEventEnable]</PostBuildEventUseInBuild>
    <PreBuildEventUseInBuild>[options.PreBuildEventEnable]</PreBuildEventUseInBuild>
    <PreLinkEventUseInBuild>[options.PreLinkEventEnable]</PreLinkEventUseInBuild>
    <OutputFile>[options.OutputFile]</OutputFile>
    <CustomBuildBeforeTargets>[options.CustomBuildStepBeforeTargets]</CustomBuildBeforeTargets>
    <CustomBuildAfterTargets>[options.CustomBuildStepAfterTargets]</CustomBuildAfterTargets>
    <ExecutablePath>[options.ExecutablePath]</ExecutablePath>
    <IncludePath>[options.IncludePath]</IncludePath>
    <LibraryPath>[options.LibraryPath]</LibraryPath>
    <ExcludePath>[options.ExcludePath]</ExcludePath>
    <UseMultiToolTask>[options.UseMultiToolTask]</UseMultiToolTask>
  </PropertyGroup>
";

            private const string _projectConfigurationsCompileTemplate =
@"    <ClCompile>
      <PrecompiledHeader>[options.UsePrecompiledHeader]</PrecompiledHeader>
      <WarningLevel>[options.WarningLevel]</WarningLevel>
      <Optimization>[options.Optimization]</Optimization>
      <PreprocessorDefinitions>[options.PreprocessorDefinitions];%(PreprocessorDefinitions)</PreprocessorDefinitions>
      <AdditionalIncludeDirectories>[options.AdditionalIncludeDirectories]</AdditionalIncludeDirectories>
      <DebugInformationFormat>[options.DebugInformationFormat]</DebugInformationFormat>
      <TreatWarningAsError>[options.TreatWarningAsError]</TreatWarningAsError>
      <OmitFramePointers>[options.OmitFramePointers]</OmitFramePointers>
      <UndefineAllPreprocessorDefinitions>false</UndefineAllPreprocessorDefinitions>
      <ExceptionHandling>[options.ExceptionHandling]</ExceptionHandling>
      <BufferSecurityCheck>[options.BufferSecurityCheck]</BufferSecurityCheck>
      <FunctionLevelLinking>[options.EnableFunctionLevelLinking]</FunctionLevelLinking>
      <DataLevelLinking>[options.EnableDataLevelLinking]</DataLevelLinking>
      <RuntimeTypeInfo>[options.RuntimeTypeInfo]</RuntimeTypeInfo>
      <AssemblerOutput>NoListing</AssemblerOutput>
      <CompileAs>Default</CompileAs>
      <UndefinePreprocessorDefinitions>[options.UndefinePreprocessorDefinitions]</UndefinePreprocessorDefinitions>
      <AdditionalOptions>[options.AdditionalCompilerOptions]</AdditionalOptions>
      <PrecompiledHeaderFile>[options.PrecompiledHeaderThrough]</PrecompiledHeaderFile>
      <ShowIncludes>[options.ShowIncludes]</ShowIncludes>
      <ForcedIncludeFiles>[options.ForcedIncludeFiles]</ForcedIncludeFiles>
      <CppLanguageStandard>[options.CppLanguageStandard]</CppLanguageStandard>
    </ClCompile>
";

            private const string _projectConfigurationsSharedLinkTemplate =
@"    <Link>
      <DebuggerSymbolInformation>[options.DebuggerSymbolInformation]</DebuggerSymbolInformation>
      <OutputFile>[options.OutputFile]</OutputFile>
      <AdditionalLibraryDirectories>[options.AdditionalLibraryDirectories]</AdditionalLibraryDirectories>
      <AdditionalOptions>[options.AdditionalLinkerOptions]</AdditionalOptions>
      <AdditionalDependencies>[options.AdditionalDependencies];%(AdditionalDependencies)</AdditionalDependencies>
      <IgnoreSpecificDefaultLibraries>[options.IgnoreDefaultLibraryNames]</IgnoreSpecificDefaultLibraries>
      <GenerateMapFile>[options.MapFileName]</GenerateMapFile>
      <IncrementalLink>[options.IncrementalLink]</IncrementalLink>
    </Link>
";

            private const string _projectConfigurationsStaticLinkTemplate =
@"    <Lib>
      <AdditionalOptions>[options.AdditionalLinkerOptions]</AdditionalOptions>
      <OutputFile>[options.OutputFile]</OutputFile>
    </Lib>
";
        }
    }
}
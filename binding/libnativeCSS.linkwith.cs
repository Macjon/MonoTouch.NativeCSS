using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith("libnativeCSS.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, Frameworks = "QuartzCore, CoreImage, Accelerate, CoreText", LinkerFlags = "-lz -all_load -ObjC")]


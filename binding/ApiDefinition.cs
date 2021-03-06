﻿//
// ApiDefinition.cs: Bindings to the native.css iOS library.
//
//	Authors:
//		J.P. Park (mailing@mono.developer.kr)
//
//
using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.NativeCSS
{
    public delegate void FetchMissingCSSAndAssetsFromURLHandler(bool success,bool cssIsDifferent,string cssContent,NSObject[] unavailableAssets);
    public delegate void UpdateCSSAndAssetsFromURLHandler(bool success,bool cssIsDifferent,string cssContent,NSObject[] unavailableAssets);
    /// <summary>
    /// Update CSS from Url.
    /// </summary>
    /// <param name="success"></param>
    /// <param name="cssIsDifferent"></param>
    /// <param name="cssContent"></param>
	public delegate void UpdateCSSFromURLHandler(bool success,bool cssIsDifferent,string cssContent);
    [BaseType(typeof(NSObject), Name = "UIApplication")]
    public interface CSSUIApplication
    {
        // +(void) styleWithCSSFile:(NSString*) filename updateFromURL:(NSURL*) remoteCSSURL refreshPeriod:(NCRemoteContentRefreshPeriod) refreshPeriod;
        [Static, Export("styleWithCSSFile:updateFromURL:refreshPeriod:")]
        void StyleWithCSSFileAndUrl(string fileName, NSUrl remoteCSSURL, int refreshPeriod);
        // +(void) styleWithCSSString:(NSString*) cssContent;
        [Static, Export("styleWithCSSString:")]
        void StyleWithCSSString(string cssContent);
        //+(void) styleWithLESSString:(NSString*) cssContent;
        [Static, Export("styleWithLESSString:")]
        void StyleWithLESSString(string cssContent);
        //+(void) styleWithLESSString:(NSString*) cssContent debugLogging:(BOOL) debugLogging;
        [Static, Export("styleWithLESSString:")]
        void StyleWithLESSString(string cssContent, bool debugLogging);
        // +(void) styleWithCSSString:(NSString*) cssContent debugLogging:(BOOL) debugLogging;
        [Static, Export("styleWithCSSString:debugLogging:")]
        void StyleWithCSSString(string cssContent, bool debugLogging);
        // +(void) fetchMissingCSSAndAssetsFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent, NSArray *unavailableAssets)) completionBlock;
        [Static, Export("fetchMissingCSSAndAssetsFromURL:completionBlock:")]
        void FetchMissingCSSAndAssetsFromURL(NSUrl url, FetchMissingCSSAndAssetsFromURLHandler completionBlock);
        // +(void) updateCSSAndAssetsFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent, NSArray *unavailableAssets)) completionBlock;
        [Static, Export("updateCSSAndAssetsFromURL:completionBlock:")]
        void UpdateCSSAndAssetsFromURL(NSUrl url, UpdateCSSAndAssetsFromURLHandler completionBlock);
        // +(void) updateCSSFromURL:(NSURL*) url completionBlock:(void (^)(BOOL success, BOOL cssIsDifferent, NSString* cssContent)) completionBlock;
        [Static, Export("updateCSSFromURL:completionBlock:")]
        void UpdateCSSFromURL(NSUrl url, UpdateCSSFromURLHandler completionBlock);
        // +(void) updateCSSFromURL:(NSURL*) url repeatInterval: (double) repeatInterval completionBlock:(void (^)(BOOL success,  BOOL cssIsDifferent, NSString* cssContent)) completionBlock;
        [Static, Export("updateCSSFromURL:repeatInterval:completionBlock:")]
        void UpdateCSSFromURL(NSUrl url, double repeatInterval, UpdateCSSFromURLHandler completionBlock);
        // +(BOOL) isAssetCachedForURL:(NSURL*) url;
        [Static, Export("isAssetCachedForURL:")]
        bool IsAssetCachedForURL(NSUrl url);
        // +(UIImage*) cachedAssetForURL:(NSURL*) url;
        [Static, Export("cachedAssetForURL:")]
        UIImage CachedAssetForURL(NSUrl url);
        // +(void) deleteCachedAssetForURL:(NSURL*) url;
        [Static, Export("deleteCachedAssetForURL:")]
        void DeleteCachedAssetForURL(NSUrl url);
        // +(void) deleteCachedAssetsFromURL:(NSURL*) url;
        [Static, Export("deleteCachedAssetsFromURL:")]
        void DeleteCachedAssetsFromURL(NSUrl url);
        // +(NSArray*) assetURLsFromURL:(NSURL*) url;
        [Static, Export("assetURLsFromURL:")]
        NSObject[] AssetURLsFromURL(NSUrl url);
        // +(void) clearCSSAssetCache;
        [Static, Export("clearCSSAssetCache")]
        void ClearCSSAssetCache();
    }

    [BaseType(typeof(NSObject), Name = "UIBarButtonItem")]
    public interface CSSUIBarButtonItem
    {
        [Static, Export("refreshCSSStylingInsideToolbar:")]
        void RefreshCssStylingInsideToolbar(UIToolbar toolbar);
    }

    [BaseType(typeof(NSObject), Name = "UICollectionViewCell")]
    public interface CSSUICollectionViewCell
    {
        [Static, Export("refreshCSSStylingWithCollectionView:cellForItemAtIndexPath:")]
        void RefreshCSSStylingWithCollectionView(UICollectionView collectionView, NSIndexPath indexPath);
    }

    [BaseType(typeof(NSObject), Name = "UIView")]
    public interface CSSUIView
    {
        [Static, Export("refreshCSSStyling")]
        void RefreshCSSStyling();

        [Static, Export("refreshCSSStylingAfterLayoutChange:")]
        void RefreshCSSStylingAfterLayoutChange(bool layoutChange);

        [Static, Export("refreshCSSStylingAndIgnoreSubviews:")]
        void RefreshCSSStylingAndIgnoreSubviews(bool ignoreSubviews);

        [Static, Export("addCSSClass:")]
        void AddCSSClass(string className);

        [Static, Export("removeCSSClass:")]
        void RemoveCSSClass(string className);

        [Static, Export("CSSClasses")]
        NSObject[] CSSClasses { get; }

        [Static, Export("cSSId")]
        string CSSId { get; set; }

        [Static, Export("viewControllerNCSSObfuscated")]
        UIViewController ViewControllerNCSSObfuscated { set; }

        [Static, Export("viewControllerForNavButtonNCSSObfuscated")]
        UIViewController ViewControllerForNavButtonNCSSObfuscated { get; }
        // removed from 0.4.0
        //[Static, Export("viewHasCSSStyle")]
        //bool ViewHasCSSSTyle { get; }
    }
}

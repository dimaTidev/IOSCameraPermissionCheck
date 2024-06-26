#import "PermissionProviderHelper.h"

@implementation PermissionProviderHelper
- (void) verifyPermission:(NSString *)NSGameObject withCallback:(NSString *)NSCallback
{
	// if (iOS >= 7) ask for camera access;
    if ([AVCaptureDevice respondsToSelector:@selector(requestAccessForMediaType:completionHandler:)]) 
    {
        [AVCaptureDevice requestAccessForMediaType:AVMediaTypeVideo completionHandler:^(BOOL granted) 
        {
            if (granted == YES) 
            { 
                UnitySendMessage(([NSGameObject cStringUsingEncoding:NSUTF8StringEncoding]), ([NSCallback cStringUsingEncoding:NSUTF8StringEncoding]), "true"); 
            }
            else 
            { 
                UnitySendMessage(([NSGameObject cStringUsingEncoding:NSUTF8StringEncoding]), ([NSCallback cStringUsingEncoding:NSUTF8StringEncoding]), "false"); 
            }
        }];
    }
	// if (iOS < 7) camera access is always permitted.
    else 
    {
        UnitySendMessage(([NSGameObject cStringUsingEncoding:NSUTF8StringEncoding]), ([NSCallback cStringUsingEncoding:NSUTF8StringEncoding]), "true");
    }
}

- (BOOL) checkPermission 
{
    // Check if the device supports the requestAccessForMediaType:completionHandler: method
    if ([AVCaptureDevice respondsToSelector:@selector(requestAccessForMediaType:completionHandler:)]) 
    {
        AVAuthorizationStatus authStatus = [AVCaptureDevice authorizationStatusForMediaType:AVMediaTypeVideo];

        if (authStatus == AVAuthorizationStatusAuthorized) {
            return YES;
        } else if (authStatus == AVAuthorizationStatusDenied) {
            return NO;
        } else if (authStatus == AVAuthorizationStatusRestricted) {
            return NO;
        } else if (authStatus == AVAuthorizationStatusNotDetermined) {
            return NO;
        } else {
            return NO;
        }
    }
    // If the device is running on iOS < 7, assume camera access is always permitted.
    else {
        return YES;
    }
}

@end

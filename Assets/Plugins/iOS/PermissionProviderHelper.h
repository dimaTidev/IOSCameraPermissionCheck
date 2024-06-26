#import <Foundation/NSException.h>
#import <AVFoundation/AVFoundation.h>
#import <UIKit/UIKit.h>

@interface PermissionProviderHelper : NSObject {}

- (void) verifyPermission:(NSString *)gameObject withCallback:(NSString *)callback;
- (BOOL) checkPermission;

@end

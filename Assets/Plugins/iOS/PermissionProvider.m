#import "PermissionProviderHelper.h"

extern void _verifyPermission(const char* gameObject, const char* callback)
{
    NSString *NSGameObject = [[NSString alloc] initWithUTF8String:gameObject];
    NSString *NSCallback = [[NSString alloc] initWithUTF8String:callback];
    
	PermissionProviderHelper* permissionProviderHelper = [[PermissionProviderHelper alloc] init];
	[permissionProviderHelper verifyPermission:NSGameObject withCallback:NSCallback];
}

extern BOOL _checkPermission()
{
    PermissionProviderHelper* permissionProviderHelper = [[PermissionProviderHelper alloc] init];
    return [permissionProviderHelper checkPermission];
}

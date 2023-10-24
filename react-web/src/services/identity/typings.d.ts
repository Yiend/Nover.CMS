declare namespace IdentityAPI {
  // 用户信息
  type IdentityUser = {
    userName: string;
    name: string;
    surname: string;
    email: string;
    emailConfirmed: string;
    phoneNumber: string;
    phoneNumberConfirmed: string;
    isActive: boolean;
    lockoutEnabled: boolean;
    accessFailedCount: number;
    lockoutEnd: Date;
    concurrencyStamp: string;
    entityVersion: number;
    lastPasswordChangeTime: Date;
  };

  type IdentityUserCreateParams = {
    userName: string;
    name: string;
    surname: string;
    password: string;
    email: string;
    phoneNumber: string;
    isActive: boolean;
    lockoutEnabled: boolean;
    roleNames: any[];
  };

  type IdentityUserUpdateParams = {
    id: string;
    userName: string;
    name: string;
    surname: string;
    password: string;
    email: string;
    phoneNumber: string;
    isActive: boolean;
    lockoutEnabled: boolean;
    roleNames: any[];
    concurrencyStamp: string;
  };

  type IdentityUserOrgCreateParams = {
    userName: string;
    name: string;
    surname: string;
    password: string;
    email: string;
    phoneNumber: string;
    isActive: boolean;
    lockoutEnabled: boolean;
    roleNames: any[];
    orgIds: any[];
  };

  type IdentityUserOrgUpdateParams = {
    id: string;
    userName: string;
    name: string;
    surname: string;
    password: string;
    email: string;
    phoneNumber: string;
    isActive: boolean;
    lockoutEnabled: boolean;
    roleNames: any[];
    concurrencyStamp: string;
    orgIds: any[];
  };

  type ListResult = {};

  type IdentityRole = {
    name: string;
    isDefault: boolean;
    isStatic: boolean;
    isPublic: boolean;
    concurrencyStamp: string;
  };
}

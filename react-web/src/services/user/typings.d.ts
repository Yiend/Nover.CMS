declare namespace USERAPI {
  type LoginResult = {
    expires_in?: string;
    token_type?: string;
    access_token?: string;
  };

  type LoginParams = {
    username: string;
    password: string;
    autoLogin: boolean;
  };

  type CurrentUser = {
    extraProperties: ExtraProperties;
    userName: string;
    email: string;
    name: string;
    surname: string;
    phoneNumber: string;
    isExternal: boolean;
    hasPassword: boolean;
    concurrencyStamp: string;
  };

  type ExtraProperties = {
    avatar: string;
    introduction: string;
  };

  type UpdateProfileParams = {
    userName: string;
    email: string;
    name: string;
    surname: string;
    phoneNumber: string;
  };

  type ChangePasswordParams = {
    avatar: string;
    introduction: string;
  };
}

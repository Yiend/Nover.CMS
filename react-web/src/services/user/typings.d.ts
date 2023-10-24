declare namespace USERAPI {
  // 登录返回
  type LoginResult = {
    expires_in?: string;
    token_type?: string;
    access_token?: string;
  };
  // 登录 请求参数
  type LoginParams = {
    username: string;
    password: string;
    autoLogin: boolean;
  };

  // 当前用户信息
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
  // 用户拓展信息
  type ExtraProperties = {
    avatar: string;
    introduction: string;
  };

  // 修改用户信息，请求参数
  type UpdateProfileParams = {
    userName: string;
    email: string;
    name: string;
    surname: string;
    phoneNumber: string;
  };

  // 修改密码，请求参数
  type ChangePasswordParams = {
    avatar: string;
    introduction: string;
  };
}

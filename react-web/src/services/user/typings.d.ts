declare namespace USERAPI{


  type LoginResult = {
    expires_in?: string;
    token_type?: string;
    access_token?: string;
  };

  type LoginParams = {
    username?: string;
    password?: string;
    autoLogin?: boolean;
  };

}

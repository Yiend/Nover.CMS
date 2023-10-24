import { request } from 'umi';
import qs from 'querystring';

const clientSetting = {
  grant_type: 'password',
  issuer: 'https://localhost:44356',
  redirectUri: 'http://localhost:44356',
  responseType: 'code',
  scope: 'address email phone profile roles CMS',
  username: '',
  password: '',
  client_id: 'CMS_App',
};

/** 登录接口 POST /api/login/account */
export async function login(body: USERAPI.LoginParams) {
  clientSetting.username = body.username.trim();
  clientSetting.password = body.password;
  return request<USERAPI.LoginResult>('/connect/token', {
    method: 'POST',
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    data: qs.stringify(clientSetting),
  });
}

/** 获取用户信息 GET /api/account/my-profile */
export async function getInfo() {
  return request<USERAPI.CurrentUser>('/api/account/my-profile', {
    method: 'GET',
  });
}

/** 修改用户信息 PUT /api/account/my-profile */
export async function setUserInfo(body: USERAPI.UpdateProfileParams) {
  return request('/api/account/my-profile', {
    method: 'PUT',
    data: body,
  });
}

/** 修改用户信息 PUT /api/account/my-profile/change-password */
export async function changePassword(body: USERAPI.ChangePasswordParams) {
  return request('/api/account/my-profile/change-password', {
    method: 'POST',
    data: body,
  });
}

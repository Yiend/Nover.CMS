import { request } from 'umi';
import qs from 'querystring';

/**
 * Auth 2.0请求参数
 */
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

/**
 * 登录接口
 * @param {USERAPI.LoginParams} body
 * @method POST
 */
export async function login(body: USERAPI.LoginParams) {
  clientSetting.username = body.username.trim();
  clientSetting.password = body.password;
  return request<USERAPI.LoginResult>('/connect/token', {
    method: 'POST',
    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    data: qs.stringify(clientSetting),
  });
}

/**
 * 获取用户信息
 * @param
 * @method GET
 */
export async function getInfo() {
  return request<USERAPI.CurrentUser>('/api/account/my-profile', {
    method: 'GET',
  });
}

/**
 * 修改用户信息
 * @param {USERAPI.UpdateProfileParams} body
 * @method PUT
 */
export async function setUserInfo(body: USERAPI.UpdateProfileParams) {
  return request('/api/account/my-profile', {
    method: 'PUT',
    data: body,
  });
}

/**
 * 修改密码
 * @param {USERAPI.ChangePasswordParams} body
 * @method POST
 */
export async function changePassword(body: USERAPI.ChangePasswordParams) {
  return request('/api/account/my-profile/change-password', {
    method: 'POST',
    data: body,
  });
}

import { request } from 'umi';
import qs from 'querystring'


const clientSetting = {
  grant_type: 'password',
  issuer: 'https://localhost:44356',
  redirectUri: 'http://localhost:44356',
  responseType: 'code',
  scope: 'address email phone profile roles CMS',
  username: '',
  password: '',
  client_id: 'CMS_App',
  //client_secret: '1q2w3e*'
}

/** 登录接口 POST /api/login/account */
export async function login(body: USERAPI.LoginParams) {
  clientSetting.username = body.username.trim();
  clientSetting.password = body.password;

  console.log(clientSetting)
  return request<USERAPI.LoginResult>('/connect/token', {
    method: 'POST',
    headers: {'Content-Type': 'application/x-www-form-urlencoded',},
    data: qs.stringify(clientSetting)
  });
}
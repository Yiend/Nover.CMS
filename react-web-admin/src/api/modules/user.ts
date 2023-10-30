import { USER } from "@/api/interface/index";
import { PORT1 } from "@/api/config/servicePort";
import qs from "qs";

import http from "@/api";

/**
 * Auth 2.0请求参数
 */
const clientSetting = {
	grant_type: "password",
	issuer: "https://localhost:44356",
	redirectUri: "http://localhost:44356",
	responseType: "code",
	scope: "address email phone profile roles CMS",
	username: "",
	password: "",
	client_id: "CMS_App"
};

/**
 * @name 用户登录接口
 * @param {USER.ReqLoginForm} params
 */
export const loginApi = (params: USER.ReqLoginForm) => {
	clientSetting.username = params.username.trim();
	clientSetting.password = params.password;

	console.log("登录参数：", clientSetting);
	return http.post<USER.ResLogin>("/connect/token", qs.stringify(params));
	/*
	return http.post<Login.ResLogin>(PORT1 + `/login`, params);
	return http.post<Login.ResLogin>(PORT1 + `/login`, {}, { params }); // post 请求携带 query 参数  ==>  ?username=admin&password=123456
	return http.post<Login.ResLogin>(PORT1 + `/login`, qs.stringify(params)); // post 请求携带 表单 参数  ==>  application/x-www-form-urlencoded
	return http.post<Login.ResLogin>(PORT1 + `/login`, params, { headers: { noLoading: true } }); // 控制当前请求不显示 loading
	*/
};

/**
 * @name 获取用户信息
 * @param
 * @method GET
 */
export const getInfo = () => http.get<USER.CurrentUser>("/api/account/my-profile");

/**
 * @name 修改用户信息
 * @param {USER.UpdateProfileParams} body
 * @method PUT
 */
export const setUserInfo = (body: USER.UpdateProfileParams) => http.put("/api/account/my-profile", body);

/**
 * @name 修改密码
 * @param {USER.ChangePasswordParams} body
 * @method POST
 */
export const changePassword = (body: USER.ChangePasswordParams) => http.post("/api/account/my-profile/change-password", body);

// * 获取按钮权限
export const getAuthorButtons = () => {
	return http.get<USER.ResAuthButtons>(PORT1 + `/auth/buttons`);
};

// * 获取菜单列表
export const getMenuList = () => {
	return http.get<Menu.MenuOptions[]>(PORT1 + `/menu/list`);
};

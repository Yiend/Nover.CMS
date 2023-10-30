// * 请求响应参数(不包含data)
export interface Result {
	code: string;
	msg: string;
}

// * 请求响应参数(包含data)
export interface ResultData<T = any> extends Result {
	data?: T;
}

// * 分页响应参数
export interface ResPage<T> {
	datalist: T[];
	pageNum: number;
	pageSize: number;
	total: number;
}

// * 分页请求参数
export interface ReqPage {
	pageNum: number;
	pageSize: number;
}

// * 登录
export namespace USER {
	export interface ReqLoginForm {
		username: string;
		password: string;
	}
	export interface ResLogin {
		expires_in: string;
		token_type: string;
		access_token: string;
	}
	export interface ResAuthButtons {
		[propName: string]: any;
	}

	// 当前用户信息
	export interface CurrentUser {
		extraProperties: ExtraProperties;
		userName: string;
		email: string;
		name: string;
		surname: string;
		phoneNumber: string;
		isExternal: boolean;
		hasPassword: boolean;
		concurrencyStamp: string;
	}

	// 用户拓展信息
	export interface ExtraProperties {
		avatar: string;
		introduction: string;
	}

	// 修改用户信息，请求参数
	export interface UpdateProfileParams {
		userName: string;
		email: string;
		name: string;
		surname: string;
		phoneNumber: string;
	}

	// 修改密码，请求参数
	export interface ChangePasswordParams {
		avatar: string;
		introduction: string;
	}
}

import http from "@/api";
import { transformAbpListQuery } from "@/utils/abp";

/**
 * @name 获取用户
 * @param {object} query
 */
export const getUsers = (query: any) => {
	return http.get("/api/identity/users", transformAbpListQuery(query));
};

/**
 * @name 根据用户Id,获取用户信息
 * @param {string} id
 */
export const getUserById = (id: string) => http.get(`/api/identity/users/${id}`);

/**
 * @name 创建用户
 * @param {object} body
 */
export const createUser = (body: any) => http.post("/api/identity/users", body);

/**
 * @name 创建用户到组织
 * @param {object} body
 */
export const createUserToOrg = (body: any) => http.post("/api/identity/users/create-to-organizations", body);

/**
 * @name 更新用户
 * @param {object} body
 */
export const updateUser = (body: any) => http.put(`/api/identity/users/${body.id}`, body);

/**
 * @name 更新用户组织
 * @param {object} body
 */
export const updateUserToOrg = (body: any) => http.put(`/api/identity/users/${body.id}/update-to-organizations`, body);

/**
 * @name 更新用户组织
 * @param {string} id
 */
export const deleteUser = (id: string) => http.delete(`/api/identity/users/${id}`);

/**
 * @name 根据用户Id,获取角色
 * @param {string} id
 */
export const getRolesByUserId = (id: string) => http.get(`/api/identity/users/${id}/roles`);

/**
 * @name 获取可分配的角色
 *
 */
export const getAssignableRoles = () => http.get("/api/identity/users/assignable-roles");

/**
 * @name 根据用户Id,获取组织
 * @param {string} id
 * @param {boolean} includeDetails
 */
export const getOrganizationsByUserId = (id: string, includeDetails = false) =>
	http.get(`/api/identity/users/${id}/organizations`, {}, { includeDetails });

/**
 * @name 添加成员到组织单元中
 * @param {string} id
 * @param {Array} ouId
 */
export const addToOrganization = (id: string, ouIds: any[]) => http.post(`/api/identity/users/${id}/add-to-organizations`, ouIds);

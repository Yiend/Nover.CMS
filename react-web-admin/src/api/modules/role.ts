import http from "@/api";
import { transformAbpListQuery } from "@/utils/abp";

/**
 * @name 获取角色列表
 * @param {object} query
 */
export const getRoles = (query: any) => http.get("/api/identity/roles", transformAbpListQuery(query));

/**
 * @name 根据角色Id,获取角色
 * @param {string} id
 */
export const getRoleById = (id: string) => http.get(`/api/identity/roles/${id}`);

/**
 * @name 创建角色
 * @param {object} query
 */
export const createRole = (body: any) => http.post("/api/identity/roles", body);

/**
 * @name 创建角色到组织
 * @param {object} query
 */
export const createRoleToOrg = (body: any) => http.post("/api/identity/roles/create-to-organization", body);

/**
 * @name 更新角色
 * @param {object} query
 */
export const updateRole = (body: any) => http.put(`/api/identity/roles/${body.id}`, body);

/**
 * @name 删除角色
 * @param {string} id
 */
export const deleteRole = (id: string) => http.delete(`/api/identity/roles/${id}`);

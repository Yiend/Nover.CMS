import http from "@/api";

/**
 * @name 获取权限列表
 * @param {object} query
 */
export const getPermissions = (query: any) => http.get("/api/permission-management/permissions", query);

/**
 * @name 修改权限
 * @param {object} query
 * @param {object} body
 */
export const updatePermissions = (query: any, body: any) => http.put(`/api/permission-management/permissions`, query, body);

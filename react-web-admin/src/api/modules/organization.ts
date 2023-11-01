import http from "@/api";
import { transformAbpListQuery } from "@/utils/abp";

/**
 * @name 获取组织与详情信息
 * @param {object} query
 */
export const getOrganizationsAllWithDetails = (query: any) => http.get("/api/identity/organizations/all/details", query);

/**
 * @name 获取组织机构
 * Example: ?filter&sorting&skipCount=0&maxResultCount=20
 * @param {object} query
 */
export const getOrganizationsWithDetails = (query: any) =>
	http.get("/api/identity/organizations/details", transformAbpListQuery(query));

/**
 * @name 获取根节点
 */
export const getOrganizationsRoot = () => http.get("/api/identity/organizations/root");

/**
 * @name 获取组织与详情信息
 * @param {string} id
 */
export const getOrganizationSingleWithDetails = (id: string) => http.get(`/api/identity/organizations/${id}/details`);

/**
 * @name 获取组织与详情信息
 * @param {string} id
 */
export const getOrganizationSingle = (id: string) => http.get(`/api/identity/organizations/${id}`);

/**
 * @name 获取组织
 *
 */
export const getOrganizationsAll = () => http.get("/api/identity/organizations/all");

/**
 * @name 获取组织
 *
 */
export const getOrganizations = (query: any) => http.get("/api/identity/organizations", transformAbpListQuery(query));

/**
 * @name 获取组织下级
 *
 */
export const getOrganizationChildren = (id: string) => http.get(`/api/identity/organizations/children/${id}`);

/**
 * @name 获取组织用户
 * @param {object} query
 */
export const getOrgUsers = (query: any) => http.get("/api/identity/organizations/users", transformAbpListQuery(query));

/**
 * @name 获取组织角色
 * @param {object} query
 */
export const getOrgRoles = (query: any) => http.get("/api/identity/organizations/roles", transformAbpListQuery(query));

/**
 * @name 创建组织
 * @param {object} body
 */
export const createOrganization = (body: any) => http.post("/api/identity/organizations", body);

/**
 * @name 更新组织
 * @param {string} id
 * @param {object} body
 */
export const updateOrganization = (id: string, body: any) => http.put(`/api/identity/organizations/${id}`, body);

/**
 * @name 删除组织
 * @param {string} id
 */
export const deleteOrganization = (id: string) => http.delete(`/api/identity/organizations/${id}`);

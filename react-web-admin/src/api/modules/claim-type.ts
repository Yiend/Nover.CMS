import http from "@/api";
import { transformAbpListQuery } from "@/utils/abp";

/**
 * @name 获取类型
 * @param {object} query
 */
export const getClaimTypes = (query: any) => http.get("/api/identity/claim-types", transformAbpListQuery(query));

/**
 * @name 创建类型
 * @param {object} body
 */
export const createClaimType = (body: any) => http.post("/api/identity/claim-types", body);

/**
 * @name 根据ID,获取类型
 * @param {string} id
 */
export const getClaimTypeById = (id: string) => http.get(`/api/identity/claim-types/${id}`);

/**
 * @name 更新类型
 * @param {object} body
 */
export const updateClaimType = (body: any) => http.put(`/api/identity/claim-types/${body.id}`, body);

/**
 * @name 删除类型
 * @param {string} id
 */
export const deleteClaimType = (id: string) => http.delete(`/api/identity/claim-types/${id}`);

/**
 * @name 获取类型
 *
 */
export const getClaimTypesAll = () => http.get("/api/identity/claim-types/all");

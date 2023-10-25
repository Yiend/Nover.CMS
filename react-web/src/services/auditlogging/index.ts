import { request } from 'umi';
import { transformAbpListQuery } from '../../utils/abp';

/**
 * 获取审计日志列表
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getAuditLogs(query: any) {
  return request('/api/audit-logging/audit-logs', {
    method: 'GET',
    params: transformAbpListQuery(query),
  });
}

/**
 * 获取审计日志
 * @param {string} id
 * @method GET
 * @returns
 */
export async function getAuditLog(id: string) {
  return request(`/api/audit-logging/audit-logs/${id}`, {
    method: 'GET',
  });
}

/**
 * 删除审计日志
 * @param {string} id
 * @method DELETE
 * @returns
 */
export async function deleteAuditLog(id: string) {
  return request(`/api/audit-logging/audit-logs/${id}`, {
    method: 'DELETE',
  });
}

/**
 * 删除多个审计日志
 * @param {Array} id
 * @method DELETE
 * @returns
 */
export async function deleteManyAuditLog(ids: any[]) {
  return request('/api/audit-logging/audit-logs/delete-many', {
    method: 'DELETE',
    data: ids,
  });
}

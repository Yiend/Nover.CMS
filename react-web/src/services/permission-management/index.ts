import { request } from 'umi';

/**
 * 获取所有权限
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getPermissions(query: any) {
  return request('/api/permission-management/permissions', {
    method: 'GET',
    params: query,
  });
}

/**
 * 更新权限
 * @param {object} query
 * @param {object} body
 * @method GET
 * @returns
 */
export async function updatePermissions(query: any, body: any) {
  return request('/api/permission-management/permissions', {
    method: 'put',
    params: query,
    data: body,
  });
}

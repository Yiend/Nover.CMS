import { request } from 'umi';

/**
 * 获取功能
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getFeatures(query: any) {
  return request('/api/feature-management/features', {
    method: 'GET',
    params: query,
  });
}

/**
 * 更新功能
 * @param {object} query
 * @param {object} body
 * @method PUT
 * @returns
 */
export async function updateFeatures(query: any, body: any) {
  return request('/api/feature-management/features', {
    method: 'PUT',
    params: query,
    data: body,
  });
}

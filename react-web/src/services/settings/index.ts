import { request } from 'umi';

/**
 * 获取所有设置
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getSettingValues() {
  return request('/api/setting-ui', {
    method: 'GET',
  });
}

/**
 * 设置系统所有配置的值
 * @param {object} body
 * @method PUT
 * @returns
 */
export async function setSettingValues(body: any) {
  return request('/api/setting-ui/set-setting-values', {
    method: 'PUT',
    data: body,
  });
}

/**
 * 重置设置的值
 * @param {object} body
 * @method PUT
 * @returns
 */
export async function resetSettingValues(body: any) {
  return request('/api/setting-ui/reset-setting-values', {
    method: 'PUT',
    data: body,
  });
}

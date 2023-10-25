import { request } from 'umi';

/**
 * 创建文件
 * @param {object} body
 * @method POST
 * @returns
 */
export async function createFile(body: any) {
  return request('/api/file-management/files/upload', {
    method: 'POST',
    data: body,
  });
}

/**
 * 获取文件
 * @param {string} name
 * @method GET
 * @returns
 */
export async function getFileByName(name: string) {
  return request(`/api/file-management/files/${name}`, {
    method: 'GET',
    options: {
      responseType: 'arraybuffer',
    },
  });
}

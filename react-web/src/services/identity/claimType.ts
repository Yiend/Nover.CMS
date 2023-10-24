import { request } from 'umi';

/**
 * 获取所有组织与详情
 * @param {object} query
 * @method GET
 * @returns
 */
// export async function getClaimTypes(query) {
//   return request('/api/identity/claim-types',{
//     method: 'GET',
//     params: transformAbpListQuery(query)
//   })
// }

/**
 * 获取所有组织与详情
 * @param {object} body
 * @method POST
 * @returns
 */
export async function createClaimType(body: object) {
  return request('/api/identity/claim-types', {
    method: 'POST',
    data: body,
  });
}

/**
 * 获取所有组织与详情
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getClaimTypeById(id: string) {
  return request(`/api/identity/claim-types/${id}`, {
    method: 'GET',
  });
}

/**
 * 获取所有组织与详情
 * @param {object} body
 * @method PUT
 * @returns
 */
// export async function updateClaimType(body: object) {
//   return request(`/api/identity/claim-types/${body.id}`, {
//     method: 'PUT',
//     data: body,
//   });
// }

/**
 * 获取所有组织与详情
 * @param {object} query
 * @method DELETE
 * @returns
 */
export async function deleteClaimType(id: string) {
  return request(`/api/identity/claim-types/${id}`, {
    method: 'DELETE',
  });
}

/**
 * 获取所有组织与详情
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getClaimTypesAll() {
  return request('/api/identity/claim-types/all', {
    method: 'GET',
  });
}

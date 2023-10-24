import { request } from 'umi';

// export async function getRoles(query) {
//   return request('/api/identity/roles', {
//     method: 'GET',
//     params: transformAbpListQuery(query),
//   });
// }

/**
 * 根据Id,获取角色信息
 * @param {string} id
 * @method GET
 * @returns
 */
export async function getRoleById(id: string) {
  return request(`/api/identity/roles/${id}`, {
    method: 'GET',
  });
}

/**
 * 创建角色
 * @param {string} body
 * @method POST
 * @returns
 */
export async function createRole(body: object) {
  return request('/api/identity/roles', {
    method: 'POST',
    data: body,
  });
}

/**
 * 创建角色到组织
 * @param {string} body
 * @method POST
 * @returns
 */
export async function createRoleToOrg(body: object) {
  return request('/api/identity/roles/create-to-organization', {
    method: 'POST',
    data: body,
  });
}

/**
 * 创建角色到组织
 * @param {string} body
 * @method PUT
 * @returns
 */
// export async function updateRole(body: object) {
//   return request(`/api/identity/roles/${body.id}`, {
//     method: 'PUT',
//     data: body,
//   });
// }

/**
 * 创建角色到组织
 * @param {string} id
 * @method DELETE
 * @returns
 */
export async function deleteRole(id: string) {
  return request(`/api/identity/roles/${id}`, {
    method: 'DELETE',
  });
}

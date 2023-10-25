import { request } from 'umi';
import { transformAbpListQuery } from '../../utils/abp';

/**
 * 获取用户信息
 * @param {object} query
 * @method GET
 */
export async function getUsers(query: object) {
  return request<IdentityAPI.IdentityUser>('/api/identity/users', {
    method: 'GET',
    params: transformAbpListQuery(query),
  });
}

/**
 * 根据用户Id,获取用户信息
 * @param {string} id
 * @method GET
 */
export async function getUserById(id: string) {
  return request<IdentityAPI.IdentityUser>(`/api/identity/users/${id}`, {
    method: 'GET',
  });
}

/**
 * 创建用户
 * @param {IdentityAPI.IdentityUserCreateParams} body
 * @method POST
 */
export async function createUser(body: IdentityAPI.IdentityUserCreateParams) {
  return request<IdentityAPI.IdentityUser>('/api/identity/users', {
    method: 'POST',
    data: body,
  });
}

/**
 * 创建用户到组织
 * @param {IdentityAPI.IdentityUserCreateParams} body
 * @method POST
 */
export async function createUserToOrg(body: IdentityAPI.IdentityUserOrgCreateParams) {
  return request<IdentityAPI.IdentityUser>('/api/identity/users/create-to-organizations', {
    method: 'POST',
    data: body,
  });
}

/**
 * 修改用户信息
 * @param {IdentityAPI.IdentityUserUpdateParams} body
 * @method PUT
 */
export async function updateUser(body: IdentityAPI.IdentityUserUpdateParams) {
  return request<IdentityAPI.IdentityUser>(`/api/identity/users/${body.id}`, {
    method: 'PUT',
    data: body,
  });
}

/**
 * 修改用户信息到组织
 * @param {IdentityAPI.IdentityUserUpdateParams} body
 * @method PUT
 */
export async function updateUserToOrg(body: IdentityAPI.IdentityUserOrgUpdateParams) {
  return request<IdentityAPI.IdentityUser>(
    `/api/identity/users/${body.id}/update-to-organizations`,
    {
      method: 'PUT',
      data: body,
    },
  );
}

/**
 * 删除用户
 * @param {string} id
 * @method DELETE
 */
export async function deleteUser(id: string) {
  return request(`/api/identity/users/${id}`, {
    method: 'DELETE',
  });
}

/**
 * 获取用户角色
 * @param {string} id
 * @method GET
 */
export async function getRolesByUserId(id: string) {
  return request(`/api/identity/users/${id}/roles`, {
    method: 'GET',
  });
}

/**
 * 获取可分配的角色
 * @param
 * @method GET
 */
export async function getAssignableRoles() {
  return request('/api/identity/users/assignable-roles', {
    method: 'GET',
  });
}

/**
 * 根据用户，获取组织
 * @param
 * @method GET
 */
export async function getOrganizationsByUserId(id: string, includeDetails: boolean = false) {
  return request(`/api/identity/users/${id}/organizations`, {
    method: 'GET',
    params: { includeDetails },
  });
}

/**
 * 添加成员到组织单元中
 * @param {string} id
 * @param {Array} ouIds
 * @method POST
 */
export function addToOrganization(id: string, ouIds: string[]) {
  return request(`/api/identity/users/${id}/add-to-organizations`, {
    method: 'POST',
    data: ouIds,
  });
}

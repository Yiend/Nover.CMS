import { request } from 'umi';

/**
 * 获取所有组织与详情
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getOrganizationsAllWithDetails(query: object) {
  return request('/api/identity/organizations/all/details', {
    method: 'GET',
    params: query,
  });
}

/**
 * 获取组织机构
 * Example: ?filter&sorting&skipCount=0&maxResultCount=20
 * @param {object} query
 */
// export async function getOrganizationsWithDetails(query) {
//   return request('/api/identity/organizations/details',{
//     method: 'GET',
//     params: transformAbpListQuery(query),
//   });
// }

/**
 * 获取组织根节点
 * @param {object} query
 * @method GET
 * @returns
 */
export async function getOrganizationsRoot() {
  return request('/api/identity/organizations/root', {
    method: 'GET',
  });
}

/**
 * 获取带有详细信息的单个组织
 * @param {string} id
 * @method GET
 * @returns
 */
export async function getOrganizationSingleWithDetails(id: string) {
  return request(`/api/identity/organizations/${id}/details`, {
    method: 'GET',
  });
}

/**
 * 获取单个组织
 * @param {string} id
 * @method GET
 * @returns
 */
export async function getOrganizationSingle(id: string) {
  return request(`/api/identity/organizations/${id}`, {
    method: 'GET',
  });
}

/**
 * 获取全部组织
 * @param
 * @method GET
 * @returns
 */
export async function getOrganizationsAll() {
  return request('/api/identity/organizations/all', {
    method: 'GET',
  });
}

/**
 * 根据条件，获取组织
 * @param {string} query
 * @method GET
 * @returns
 */
// export async function getOrganizations(query) {
//   return request( '/api/identity/organizations',{
//     method: 'GET',
//     params: transformAbpListQuery(query),
//   });
// }

/**
 * 根据条件，获取组织
 * @param {string} pid
 * @method GET
 * @returns
 */
export async function getOrganizationChildren(pid: string) {
  return request(`/api/identity/organizations/children/${pid}`, {
    method: 'GET',
  });
}

// export async function getOrgUsers(query) {
//   return request('/api/identity/organizations/users', {
//     method: 'GET',
//     params: transformAbpListQuery(query),
//   });
// }

// export async function getOrgRoles(query) {
//   return request('/api/identity/organizations/roles',{
//     method: 'GET',
//     params: transformAbpListQuery(query),
//   });
// }

/**
 * 根据条件，获取组织
 * @param {string} pid
 * @param {object} body
 * @method PUT
 * @returns
 */
export async function createOrganization(body: object) {
  return request('/api/identity/organizations', {
    method: 'POST',
    data: body,
  });
}

/**
 * 根据条件，获取组织
 * @param {string} pid
 * @param {object} body
 * @method PUT
 * @returns
 */
export async function updateOrganization(id: string, body: object) {
  return request(`/api/identity/organizations/${id}`, {
    method: 'PUT',
    data: body,
  });
}

/**
 * 根据条件，获取组织
 * @param {string} pid
 * @method DELETE
 * @returns
 */
export async function deleteOrganization(id: string) {
  return request(`/api/identity/organizations/${id}`, {
    method: 'DELETE',
  });
}

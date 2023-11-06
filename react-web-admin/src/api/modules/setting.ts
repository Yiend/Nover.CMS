import http from "@/api";

/**
 * @name 获取设置列表
 * @param {object} query
 */
export const getSettingValues = () => http.get("/api/setting-ui");

/**
 * @name 设置配置的值
 * @param {Array} values
 */
export const setSettingValues = (values: any[]) => http.put("/api/setting-ui/set-setting-values", values);

/**
 * @name 重置配置的值
 * @param {Array} values
 */
export const resetSettingValues = (values: any[]) => http.put("/api/setting-ui/reset-setting-values", values);

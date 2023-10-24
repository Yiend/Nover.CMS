const baseListQuery = {
  page: 1,
  limit: 20,
  sort: undefined,
  filter: undefined,
};

export function transformAbpListQuery(query) {
  query.filter = query.filter === '' ? undefined : query.filter;

  const abpListQuery = {
    maxResultCount: query.limit,
    skipCount: (query.page - 1) * query.limit,
    sorting:
      query.sort && query.sort.endsWith('ending') ? query.sort.replace('ending', '') : query.sort,
    ...query,
  };

  delete abpListQuery.page;
  delete abpListQuery.limit;
  delete abpListQuery.sort;

  return abpListQuery;
}

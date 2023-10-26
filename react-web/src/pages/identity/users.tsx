import React, { Component } from 'react';

export default class users extends Component {
  tabList = [
    {
      key: 'articles',
      tab: '文章',
    },
    {
      key: 'projects',
      tab: '项目',
    },
    {
      key: 'applications',
      tab: '应用',
    },
  ];

  handleTabChange = (key) => {
    const { match } = props;
    const url = match.url === '/' ? '' : match.url;
    switch (key) {
      case 'articles':
        history.push(`${url}/articles`);
        break;
      case 'applications':
        history.push(`${url}/applications`);
        break;
      case 'projects':
        history.push(`${url}/projects`);
        break;
      default:
        break;
    }
  };

  handleFormSubmit = (value) => {
    console.log(value);
  };

  getTabKey = () => {
    const { match, location } = props;
    const url = match.path === '/' ? '' : match.path;
    const tabKey = location.pathname.replace(`${url}/`, '');
    if (tabKey && tabKey !== '/') {
      return tabKey;
    }
    return 'articles';
  };

  render() {
    return (
      <PageContainer
        content={
          <div style={{ textAlign: 'center' }}>
            <Input.Search
              placeholder="请输入"
              enterButton="搜索"
              size="large"
              onSearch={handleFormSubmit}
              style={{ maxWidth: 522, width: '100%' }}
            />
          </div>
        }
        tabList={tabList}
        tabActiveKey={getTabKey()}
        onTabChange={handleTabChange}
      >
        {props.children}
      </PageContainer>
    );
  }
}

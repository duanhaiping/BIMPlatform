const ENV = {
  dev: {
    apiUrl: 'http://localhost:44312',
    oAuthConfig: {
      issuer: 'http://localhost:44312',
      clientId: 'BIMPlatform_App',
      clientSecret: '1q2w3e*',
      scope: 'BIMPlatform',
    },
    localization: {
      defaultResourceName: 'BIMPlatform',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44312',
    oAuthConfig: {
      issuer: 'http://localhost:44312',
      clientId: 'BIMPlatform_App',
      clientSecret: '1q2w3e*',
      scope: 'BIMPlatform',
    },
    localization: {
      defaultResourceName: 'BIMPlatform',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};

export const environment = {
  production: true,
  application: {
    name: 'BIMPlatform',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44312',
    clientId: 'BIMPlatform_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'BIMPlatform',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44312',
    },
  },
  localization: {
    defaultResourceName: 'BIMPlatform',
  },
};

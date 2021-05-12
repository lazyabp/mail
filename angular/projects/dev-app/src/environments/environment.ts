import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Mailing',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44335',
    redirectUri: baseUrl,
    clientId: 'Mailing_App',
    responseType: 'code',
    scope: 'offline_access Mailing role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44335',
      rootNamespace: 'Lazy.Abp.Mailing',
    },
    Mailing: {
      url: 'https://localhost:44353',
      rootNamespace: 'Lazy.Abp.Mailing',
    },
  },
} as Environment;

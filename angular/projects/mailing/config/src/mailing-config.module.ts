import { ModuleWithProviders, NgModule } from '@angular/core';
import { MAILING_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class MailingConfigModule {
  static forRoot(): ModuleWithProviders<MailingConfigModule> {
    return {
      ngModule: MailingConfigModule,
      providers: [MAILING_ROUTE_PROVIDERS],
    };
  }
}

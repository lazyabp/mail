import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { MailingComponent } from './components/mailing.component';
import { MailingRoutingModule } from './mailing-routing.module';

@NgModule({
  declarations: [MailingComponent],
  imports: [CoreModule, ThemeSharedModule, MailingRoutingModule],
  exports: [MailingComponent],
})
export class MailingModule {
  static forChild(): ModuleWithProviders<MailingModule> {
    return {
      ngModule: MailingModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<MailingModule> {
    return new LazyModuleFactory(MailingModule.forChild());
  }
}

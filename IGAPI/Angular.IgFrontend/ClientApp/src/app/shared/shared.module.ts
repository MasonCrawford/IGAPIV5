import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from "@angular/forms";

import {SharedRoutingModule} from './shared-routing.module';
import {NavComponent} from './components/nav/nav.component';
import {BarComponent} from './components/bar/bar.component';
import {PageLayoutComponent} from './components/page-layout/page-layout.component';

@NgModule({
  declarations: [NavComponent, BarComponent, PageLayoutComponent],
  imports: [
    CommonModule,
    SharedRoutingModule,
    FormsModule
  ],
  exports: [NavComponent, BarComponent, PageLayoutComponent]

})
export class SharedModule {
}

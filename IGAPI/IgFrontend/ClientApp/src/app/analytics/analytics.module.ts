import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AnalyticsRoutingModule} from './analytics-routing.module';
import {AnalyticsComponent} from './analytics.component';
import {MetricCardComponent} from './components/metric-card/metric-card.component';
import {GraphCardComponent} from './components/graph-card/graph-card.component';
import {TableCardComponent} from './components/table-card/table-card.component';
import {SharedModule} from "../shared/shared.module";

@NgModule({
  declarations: [
    MetricCardComponent,
    GraphCardComponent,
    TableCardComponent,
    AnalyticsComponent
  ],
  exports: [
    MetricCardComponent
  ],
  imports: [
    CommonModule,
    AnalyticsRoutingModule,
    SharedModule
  ]
})
export class AnalyticsModule {
}

import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AnalyticsRoutingModule} from './analytics-routing.module';
import {AnalyticsComponent} from './analytics.component';
import {MetricCardComponent} from './components/metric-card/metric-card.component';
import {GraphCardComponent} from './components/graph-card/graph-card.component';
import {TableCardComponent} from './components/table-card/table-card.component';
import {SharedModule} from "../shared/shared.module";
import {NgChartsModule} from "ng2-charts";

@NgModule({
  declarations: [
    MetricCardComponent,
    GraphCardComponent,
    TableCardComponent,
    AnalyticsComponent
  ],
  imports: [
    CommonModule,
    AnalyticsRoutingModule,
    SharedModule,
    NgChartsModule
  ]
})
export class AnalyticsModule {
}

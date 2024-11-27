import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-metric-card',
  templateUrl: './metric-card.component.html',
  styleUrls: ['./metric-card.component.scss']
})
export class MetricCardComponent implements OnInit {

  @Input() lable: string = "";
  @Input() value: string = "";
  @Input() color: string = "";
  @Input() icon: string = "";

  constructor() {
  }

  ngOnInit(): void {
  }

}
